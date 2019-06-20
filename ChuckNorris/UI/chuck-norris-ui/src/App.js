import React from 'react';
import Background from './components/background/background';
import './App.css';
import RandomJoke from './components/randomJoke/randomJoke';
import SearchJokes from './components/searchJokes/searchJokes';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Background />
        <RandomJoke />
        <SearchJokes />
      </header>
    </div>
  );
}

export default App;
