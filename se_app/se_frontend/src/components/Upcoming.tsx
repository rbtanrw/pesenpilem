import './Showing.css'
const Upcoming = (props: { url: string }) => {
    return (
        <div>
            <div className="upcoming">
                <div className="upcomingmovie">Upcoming Movie</div>
                <img src={props.url} alt="" />
                <div className="buttonwrapper">
                    <button id="booknow">Book Now</button>
                    <button id="playtrailer">Play Trailer</button>
                </div>


            </div>
        </div>

    )
}
export default Upcoming