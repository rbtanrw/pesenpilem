import { useContext } from "react"
import Showing from "../components/Showing"
import Upcoming from "../components/Upcoming"
import data from './apitest.json'
import './Home.css'
import { Link, useLocation, useNavigate, useParams } from "react-router-dom"
import { UserCtx } from "../context/UserContext"
import NavBar from "../components/CoolNavBar"

const Home = () => {
    const { user } = useContext(UserCtx)
    
    console.log(user)
    return (
        <div>
            <NavBar />
            <div className="Home">
                <div className="other">
                    <div className="comingsoonwrapper">
                        <img src="/nyehehehe.jpg" alt="" />
                        <div className="comingsoon">Coming Soon</div>
                    </div>
                </div>
                <div className="movies">
                    <Upcoming url="/interstellar.jpg" />
                    <div className="nowshowingcontainer">
                        <div className="nowshowing">
                            <h1>Now Showing:</h1>
                            <div className="line"></div>
                        </div>
                        <div className="showingcontainer">
                            {
                                data.map((Theater) => (
                                    <Showing url="/nyehehehe.jpg" title={Theater.Movie.MovieName} genre={Theater.Movie.GenreName} />
                                ))
                            }

                        </div>
                    </div>

                </div>
            </div>
        </div>

    )
}
export default Home
