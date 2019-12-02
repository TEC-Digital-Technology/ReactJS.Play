import { Action, Reducer } from 'redux';
import { AppThunkAction } from './';
import { SigninRequest } from './Request/API002Account/SigninRequest';
import { SigninResponse } from './Response/API002Account/SigninResponse';
import * as Account from './Account';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface SigninState {
    account: string;
}
// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.


// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = SigninRequest | SigninResponse | Account.UpdateAccountInfo;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    onSubmit: (values: any): AppThunkAction<KnownAction> => async (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        const appState = getState();
        //Synchronized Version
        if (appState) {
            dispatch({ type: 'REQUEST_ACCOUNT_SIGNIN', account: values.account, password: values.password });
            const response = await fetch(`api/API002Account/Signin`, {
                method: 'POST',
                body: JSON.stringify({ Account: values.account, Password: values.password }),
                headers: new Headers({
                    'Content-Type': 'application/json'
                })
            });
            const responseJson = response.json() as Promise<SigninResponse>;
            await responseJson.then(data => {
                dispatch({ type: 'RESPONSE_ACCOUNT_SIGNIN', resultCode: data.resultCode, resultMessage: data.resultMessage, accessToken: data.accessToken });
                dispatch({ type: 'UPDATE_ACCOUNT_INFO', accessToken: data.accessToken });
            });
        }
        //Asynchornized Version
        // if (appState) {
        //     fetch(`api/API002Account/Signin`, {
        //         method: 'POST',
        //         body: JSON.stringify({ Account: values.account, Password: values.password }),
        //         headers: new Headers({
        //             'Content-Type': 'application/json'
        //         })
        //     })
        //         .then(response => response.json() as Promise<SigninResponse>)
        //         .then(data => {
        //             dispatch({ type: 'RESPONSE_ACCOUNT_SIGNIN', resultCode: data.resultCode, resultMessage: data.resultMessage });
        //         });
        //     dispatch({ type: 'REQUEST_ACCOUNT_SIGNIN', account: values.account, password: values.password });
        // }
    },
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.
const unloadedState: SigninState = { account: "" };

export const reducer: Reducer<SigninState> = (state: SigninState | undefined, incomingAction: Action): SigninState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_ACCOUNT_SIGNIN':
            return {
                account: action.account
            };
        case 'RESPONSE_ACCOUNT_SIGNIN':
            return {
                account: state.account
            };
    }

    return state as SigninState;
};
