import './MoviePoster.css'
const MoviePoster = (props:{url:string, title:string, genre:string, duration:string})=>{
    return(
        <div className="movieposter">
            <img src={props.url} alt="" />
            <h2>{props.title}</h2>
            <p>{props.genre}<br/>{props.duration}</p>
        </div>
    )
}
export default MoviePoster