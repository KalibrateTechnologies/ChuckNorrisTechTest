import React from 'react';
import chuck_norris from '../../media/chuck_norris.png';
import './background.css';

function Background() {
  return (
    <img src={chuck_norris} className="Back-logo" alt="Chuck Norris!" />
  );
}

export default Background;
