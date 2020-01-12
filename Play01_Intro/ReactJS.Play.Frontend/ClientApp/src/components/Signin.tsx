import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { } from 'react-router-dom';
import { ApplicationState } from '../store';
import * as SigninStore from '../store/Signin';
import Label from 'reactstrap/lib/Label';
import Button from 'reactstrap/lib/Button';
import { Field, reduxForm, formValueSelector, InjectedFormProps, FormStateMap } from 'redux-form';
import { FormGroup, Input, Form } from 'reactstrap';

// At runtime, Redux will merge together...
type SigninProps =
    InjectedFormProps<SigninStore.SigninState> &
    SigninStore.SigninState // ... state we've requested from the Redux store
    & typeof SigninStore.actionCreators // ... plus action creators we've requested
    & RouteComponentProps<{}>; // ... plus incoming routing parameters

const SignInForm: React.FunctionComponent<SigninProps> = (props) => {
    const { handleSubmit, pristine, reset, submitting } = props;
    return (
        <Form onSubmit={handleSubmit}>
            <FormGroup>
                <Label for="account">帳號</Label>
                <Field
                    name="account"
                    component="input"
                    type="text"
                    placeholder="Account"
                />
            </FormGroup>
            <FormGroup>
                <Label for="password">密碼</Label>
                <Field
                    name="password"
                    component="input"
                    type="password"
                    placeholder="Password"
                />
            </FormGroup>
            <div>
                <Button color="primary" disabled={pristine || submitting}>登入</Button>{" "}
                <Button
                    color="primary"
                    disabled={pristine || submitting}
                    onClick={reset}>清除</Button>
            </div>
        </Form>
    );
};

let result = reduxForm({
    form: 'signInForm',
})(SignInForm as any);

export default connect(
    (state: ApplicationState) => ({
        ...state.signin,
        initialValues: state.signin
    }),
    {
        ...SigninStore.actionCreators
    }
)(result);

