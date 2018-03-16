import React from 'react';
import {Link} from 'react-router-dom';
import Footer from '../src/Components/footer';

class NavBar extends React.Component{
    render(){
        return(
            <div>
                <nav className="navbar navbar-inverse">
                    <div className="container-fluid">
                        <div className="navbar-header">
                            <Link to="/app" className="navbar-brand">OOP</Link>
                        </div>
                        <ul className="nav navbar-nav">
                            {/* <li><Link to="/register">Register</Link></li>
                            <li><Link to="/login">Login</Link></li> */}
                        </ul>
                        <form className="navbar-form navbar-left" action="/action_page.php">
                            <div className="input-group">
                                <input type="text" className="form-control" placeholder="Search" name="search"/>
                                <div className="input-group-btn">
                                    <button className="btn btn-default" type="submit">
                                        <i className="glyphicon glyphicon-search"></i>
                                    </button>
                                </div>
                            </div>
                        </form>
                        <ul className="nav navbar-nav pull-right">
                            <li><img src="https://cdn-images-1.medium.com/max/1920/1*-4nkXQYN05ljzfJez_azbg.jpeg" className="profilePic img-circle" alt="profilePic"/></li>
                            <li><a href="/app"> Matt <i/></a></li>
                            <li><a href="/messages"><i className="fas fa-inbox"/><span className="badge">5</span></a></li>
                            <li><a href="/login">Logout </a></li>
                        </ul>
                    </div>
                </nav>
                <div>
                    {this.props.children}
                </div> 
                <Footer/>
            </div>
        );
    }
}
export default NavBar;
