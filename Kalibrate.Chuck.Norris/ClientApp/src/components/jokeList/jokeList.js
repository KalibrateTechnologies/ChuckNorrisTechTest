import React, { Component } from 'react';
import './jokeList.css';

class JokeList extends Component {

  render() {
        if (this.props.jokes && this.props.jokes.length > 0) {
            return (
                <ul>
                    {this.props.jokes.map(j =>
                        <li>{j.value}</li>
                    )}
                </ul>
            );
        } else if (this.props.jokes && this.props.jokes.length === 0) {
            return (
                <div><span>No Results Found!</span></div>
            );
        }
        else if (this.props.error) {
            return (
                <div>
                    <span>error</span>
                </div>
            );
      }

      return (<div><span>Please enter a search term...</span></div>)
  }
}

export default JokeList;