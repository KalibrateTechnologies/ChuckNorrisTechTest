import React, { Component } from 'react';
import Loading from '../loading/loading';
import './randomJoke.css';

class RandomJoke extends Component {
  constructor(props) {
    super(props);

    this.state = {
      data: null,
    };

    this.refreshRandomJoke = this.refreshRandomJoke.bind(this);
    this.updateRamdomJoke = this.updateRamdomJoke.bind(this);
  }

  updateRamdomJoke() {
    fetch('http://chucknorris/chucknorrisapi/api/chucknorris')
      .then(response => response.json())
      .then(data => this.setState({ data }))
      .catch(error => this.setState({ error, isLoading: false }));
  }

  componentDidMount() {
    this.updateRamdomJoke();
  }

  refreshRandomJoke() {
    this.updateRamdomJoke();
  }

  render() {
      const { data, error } = this.state;
        if (data) {
            return (
                <div>
                    <div>
                        <span>{data.value}</span>
                    </div>
                    <div>
                        <button className="refresh" onClick={this.refreshRandomJoke}>
                            Refresh Random Joke
                        </button>
                    </div>
                </div>
            );
        }

        if (error) {
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
}

export default RandomJoke;