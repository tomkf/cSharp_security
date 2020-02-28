import React from 'react';

const BASE_URL        = 'https://localhost:44374/api/';

class ToDoController extends React.Component {
    constructor() {
        super();
        this.state  = { 
            todoItems: [],
            render: false
         }
        }
    
    componentDidMount(){
        try {
        fetch(BASE_URL + 'ToDO')
            .then((response) => {
            return response.json();
             })
            .then((data) => {
              //this.pushState(data)
              this.setState({ todoItems: data, render: true})
              console.log(this.state)
                }) 
              }
          catch(error) {
            alert(error);
          }
         }

        // pushState(jsonData){
        //     let workingArray = []

        //     jsonData.forEach(item => {
        //         workingArray.push(item)
        //     });

        //     this.setState((prevState) => { return { todoItems: workingArray}})
        // }

        renderView(toDoState){
           let todoItems =  toDoState.map(item => (<span > {item} {item.description}</span>))
               return (<div> {todoItems} </div>)
         }

        // this.state.todoItems.map((item, index)=>( <li key={item}>{index} {item} {item.description}</li> ))
        
        render(){
        return(<div> 
            {this.state.render ? this.renderView( this.state.todoItems) : ""} 
            </div>)
    }
}

export default ToDoController;