import React from 'react';
import './loading.css';
import logo from '../../media/logo.svg';

function Loading() {
  return (
    <img src={logo} className="loading" alt="Loading!" />
  );
}

export default Loading;