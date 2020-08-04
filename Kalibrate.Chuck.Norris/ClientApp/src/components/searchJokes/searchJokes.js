import React, { Component } from 'react';
import './searchJokes.css';
import JokeList from '../jokeList/jokeList'

class SearchJokes extends Component {
    constructor(props) {
        super(props);

        this.state = {
            data: null,
            searchTerm: null
        };

        this.searchJokes = this.searchJokes.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    searchJokes(event) {
        fetch(`/api/chucknorris/search?query=${this.state.searchTerm}`)
            .then(response => response.json())
            .then(data => this.setState({ data }))
            .catch(error => this.setState({ error }));
        event.preventDefault();
    }

    handleChange(event) {
        this.setState({ searchTerm: event.target.value });
    }

    render() {

        const { data, error } = this.state;

        return (
            <div>
                <div>
                    <form onSubmit={this.searchJokes}>
                        <label>
                            Search:
                            <input type="text" value={this.state.searchTerm} onChange={this.handleChange} />
                        </label>
                        <input type="submit" className="search" value="Search" />
                    </form>
                    <JokeList jokes={data} error={error} />
                </div>
            </div>
        );
    }
}

export default SearchJokes;