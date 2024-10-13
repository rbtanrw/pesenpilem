import { MouseEventHandler, useContext, useState } from 'react'
import MovieBanner from '../components/MovieBanner'
import MoviePoster from '../components/MoviePoster'
import data from './apitest.json'
import './Movie.css'
import { useNavigate } from 'react-router-dom'
import { UserCtx } from '../context/UserContext'
import NavBar from '../components/CoolNavBar'
const Movie = (props: { index: number }) => {
    const { user, setUser } = useContext(UserCtx)
    const [popup, setPopup] = useState(false)
    const nav = useNavigate()

    const greenClick = (seat: string) => {
        if (!user.seats.includes(seat)) {
            setUser((prevUser: { seats: any }) => ({
                ...prevUser,
                seats: [...prevUser.seats, seat]
            }))
        }
    }
    const yellowClick = (seat: string) => {
        if (user.seats.includes(seat)) {
            setUser((prevUser: { seats: any }) => ({
                ...prevUser,
                seats: prevUser.seats.filter((existingSeat: string) => existingSeat != seat)
            }))
        }
    }
    console.log(user.seats)
    return (
        <div className='movie'>
            <NavBar/>
            {user.username != '' ?
                <div className="moviecontainer">
                    <div className="posterwrapper">
                        <img src="/nyehehehe.jpg" alt="" />
                    </div>
                    <div className="movieinfowrapper">
                        <div className="movieinfo">
                            <div className="leftinfo">
                                <h1>{data[props.index].Movie.MovieName}</h1>
                                <h3>{data[props.index].Movie.GenreName}</h3>
                                <h3>{data[props.index].Movie.MovieDuration}, {data[props.index].Movie.MovieTime}</h3>
                            </div>
                            <div className="rightinfo">
                                {user.seats.length == 0 ? <button className='disabledbutton'>Confirm Selection</button> : <button className='enabledbutton' onClick={() => setPopup(true)}>Confirm Selection</button>}
                            </div>
                        </div>
                        <div className="line" />
                        <div className="theater">
                            <div className="seats">
                                {data[props.index].Seats.map((row, rowindex) => (
                                    <div className="row">
                                        {row.map((col, colindex) => (
                                            <div>
                                                {col === 1 ? (
                                                    user.seats.includes(String.fromCharCode(rowindex + 65) + colindex) ? (
                                                        <button key={colindex} className="yellowbutton" onClick={() => { yellowClick(String.fromCharCode(rowindex + 65) + colindex) }} > {String.fromCharCode(rowindex + 65)}{colindex}</button>
                                                    ) : (
                                                        <button key={colindex} className="greenbutton" onClick={() => { greenClick(String.fromCharCode(rowindex + 65) + colindex) }}>{String.fromCharCode(rowindex + 65)}{colindex}</button>
                                                    )
                                                ) : (
                                                    <button key={colindex} className="redbutton">{String.fromCharCode(rowindex + 65)}{colindex}</button>
                                                )
                                                }
                                            </div>
                                        ))}
                                    </div>
                                ))}
                                <div className="screen">Screen</div>
                            </div>
                        </div>
                    </div>
                </div>
                :
                <div className="loginplis" style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', color: 'white', height: '100vh', flexDirection: 'column' }}>
                    <h1>Login to book your ticket</h1>
                    <div className="line" style={{ width: 400 }}></div>

                </div>
            }
            {popup ? <div>
                <div className='confoverlay'>
                    <div style={{ display: 'flex', justifyContent: 'space-between', flexShrink: 1 }}>
                        <h1>Transaction has been added</h1>
                        <p style={{ fontSize: 32, cursor: 'pointer' }} onClick={() => setPopup(false)}>×</p>
                    </div>

                    <div className="line" />
                    <h3>Your seats:</h3>
                    <p>
                        {user.seats.map((seat: string) => seat + ", ")}
                    </p>
                </div>
                <div className="overlay">ass</div>
            </div> :<></>
            }


        </div>
    )
}
export default Movie