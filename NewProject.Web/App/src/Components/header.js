import React from 'react';
import logo from '../logo.svg';
import '../Styles/App.css';
import '../Styles/index.css';
// import alleyOOP from '../alleyOOP.png';

class Header extends React.Component{
    render(){
        return(
            <header className="App-header">
              {/* <img src={alleyOOP} alt="alleyOOP"/> */}
              <h1 className="App-title">alley OOP<img src={logo} className="App-logo" alt="logo" /></h1>
            </header>
        )
    }
}
export default Header;