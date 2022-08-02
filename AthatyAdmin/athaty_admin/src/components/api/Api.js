import React, { Component } from 'react'
import axios from 'axios'

export class Api extends Component {

    constructor() {
      super()
    
      this.state = {
         First : []
      }
    }
static BaseUrl = 'https://localhost:7042/';

static getCategories = () =>{
    axios.get(this.BaseUrl+'categories')
    .then(result =>{
        console.log(result.data[0].Id)
    })
}

static addCategories = () =>{
    const myNewObject = {Name:'Electro'};
    axios.post(this.BaseUrl+'categories',myNewObject)
}

  render() {
    return (
      <div>Api</div>
    )
  }
}

export default Api