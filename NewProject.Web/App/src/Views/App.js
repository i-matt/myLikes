import React from 'react';

class App extends React.Component {
  constructor(props){
    super(props);
    this.state = {};
  }

  handleChange = (event) => {
    this.setState({value: event.target.value});
  }

  handlePanelColor = (value) => {
    let colors = [
      "panel-success",
      "panel-info",
      "panel-warning",
      "panel-danger",
      "panel-default"
    ];
    console.log(value);
  }
  render() {
    return (
      <div className= "container">
        <div className="App">
          <p>This is my app</p>
          <div className="form-group">
          <label>Select a color:</label>
            <select value={this.state.value} onChange={this.handleChange} className="form-control" id="panelColor">
              <option value="0">Green</option>
              <option value="1">Blue</option>
              <option value="2">Yellow</option>
              <option value="3">Red</option>
              <option value="4">None</option>
            </select>
          </div>
          <button onClick={()=>this.handlePanelColor(this.state.value)}className= "btn btn-primary">Ok</button>
          <div className="panel-group">
            <div className="panel panel-default">
              <div className="panel-heading">Panel with panel-default class</div>
              <div className="panel-body">Panel Content</div>
            </div>

            <div className="panel panel-primary">
              <div className="panel-heading">Panel with panel-primary class</div>
              <div className="panel-body">Panel Content</div>
            </div>

            <div className="panel panel-success">
              <div className="panel-heading">Panel with panel-success class</div>
              <div className="panel-body">Panel Content</div>
            </div>

            <div className="panel panel-info">
              <div className="panel-heading">Panel with panel-info class</div>
              <div className="panel-body">Panel Content</div>
            </div>

            <div className="panel panel-warning">
              <div className="panel-heading">Panel with panel-warning class</div>
              <div className="panel-body">Panel Content</div>
            </div>

            <div className="panel panel-danger">
              <div className="panel-heading">Panel with panel-danger class</div>
              <div className="panel-body">Panel Content</div>
            </div>
          </div>
                </div>
      </div>
    );
  }
}

export default App;
