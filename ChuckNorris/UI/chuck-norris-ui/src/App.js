import React from 'react';
import Background from './components/background/background';
import './App.css';
import RandomJoke from './components/randomJoke/randomJoke';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Background />
        <RandomJoke />
      </header>
    </div>
  );
}

export default App;
