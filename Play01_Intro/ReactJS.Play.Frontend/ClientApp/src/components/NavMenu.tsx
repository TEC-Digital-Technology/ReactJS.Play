import * as React from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link, RouteComponentProps } from 'react-router-dom';
import './NavMenu.css';
import * as Account from '../store/Account';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import { combineReducers } from 'redux';

type NavProps =
    Account.CurrentAccountInfo // ... state we've requested from the Redux store
    & typeof Account.actionCreators  // ... plus action creators we've requested
    & RouteComponentProps<{}>; // ... plus incoming routing parameters


class NavMenu extends React.PureComponent<NavProps, { isOpen: boolean }> {
    public state = {
        isOpen: false
    };

    public render() {
        return (
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow mb-3" light>
                    <Container>
                        <NavbarBrand tag={Link} to="/">ReactJS.Play.Frontend ({this.props.isAuthenticated ? "Loggin In" : "Anonymous"})</NavbarBrand>
                        <NavbarToggler onClick={this.toggle} className="mr-2" />
                        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={this.state.isOpen} navbar>
                            <ul className="navbar-nav flex-grow">
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/signin">Signin</NavLink>
                                </NavItem>
                            </ul>
                        </Collapse>
                    </Container>
                </Navbar>
            </header>
        );
    }

    private toggle = () => {
        this.setState({
            isOpen: !this.state.isOpen
        });
    }
}

// export default NavMenu
export default connect(
    (state: ApplicationState) => state.account,
    { ...Account.actionCreators }
)(NavMenu as any);