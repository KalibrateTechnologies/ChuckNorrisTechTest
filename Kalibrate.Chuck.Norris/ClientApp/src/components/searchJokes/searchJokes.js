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
        // ('/api/chucknorris/search?query=' + this.state.searchTerm)

        event.preventDefault();
    }

    handleChange(event) {
        this.setState({ searchTerm: event.target.value });
    }

    render() {
        const { data, error } = this.state;

        return (
            <div>
                Implement Me
            </div>
        );
    }
}

export default SearchJokes;