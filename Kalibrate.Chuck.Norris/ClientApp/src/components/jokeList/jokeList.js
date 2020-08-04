import React, { Component } from 'react';
import Loading from '../loading/loading';
import './jokeList.css';

class JokeList extends Component {

  render() {
      if (this.props && (this.props.jokes || this.props.error)) {
          if (this.props.jokes.result) {
              return (
                  <div>Implement ME</div>
              );
          }

          if (this.props.error) {
              return (
                  <div>
                      <span>error</span>
                  </div>
              );
          }

          return (
              <Loading />
          );
      }

      return (
          <div><span>No Results Found!</span></div>
      );
  }
}

export default JokeList;