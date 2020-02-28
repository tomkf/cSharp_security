import React from 'react';
import { BrowserRouter as Router, Route} from "react-router-dom";

import AppController from './components/AppController'
import ToDoController from './components/ToDoController'

class App extends React.Component {
    render() {
        return (          
            <div>
              <Router>
              <Route path="/" exact> < AppController/> </Route>
              <Route path="/todo" component={ToDoController} />
            </Router>
            </div>     
        )
    }
}

export default App;

// <Router>
// <div>
// <Route path="/" exact> <Home /> </Route>
// <Route path="/about"> <About /> </Route>
// <Route path="/discover"> <Discover /> </Route>
// <Route path="/favorites"> <Favorites /> </Route>
// <Route path="/ratings"> <MyRated /> </Route>
// <Route path="/movie/:id"  component={MoviePage} /> 
// <Route path="/search/:id"  component={ResultPage} /> 
// </div>
// </Router>