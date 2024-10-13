import React from 'react';
import logo from './logo.svg';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import './App.css';
import Home from './pages/Home';
import LogReg from './pages/LogReg';
import Movie from './pages/Movie';
import data from './pages/apitest.json'
import UserProvider from './context/UserContext';
import Transactions from './pages/Transactions';
function App() {
  data.map((t, tindex) => {
    console.log('/' + data[tindex].Movie.MovieName)
  })
  return (
    <UserProvider>
      <Router>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/loginregister" element={<LogReg />} />
          {data.map((theater, theaterIndex) => (
            <Route
              key={theaterIndex}
              path={"/" + data[theaterIndex].Movie.MovieName.replace(/\s/g, '')}
              element={<Movie index={theaterIndex} />}
            />
          ))}
          <Route path="/transactions" element={<Transactions/>}/>
        </Routes>
      </Router>
    </UserProvider>

  )
}

export default App;
