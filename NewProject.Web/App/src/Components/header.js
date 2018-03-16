import React from 'react';
import '../Styles/App.css';
import '../Styles/index.css';
import final from '../Images/final.gif';

class Header extends React.Component{
    render(){
        return(
            <header className="App-header">
              <h1 className="App-title"><font color="#61DAFB">alley OOP</font><img src={final} className="App-logo" alt="logo" /></h1>
            </header>
        )
    }
}
export default Header;