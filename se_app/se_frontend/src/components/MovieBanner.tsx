import './MovieBanner.css'
const MovieBanner = (props:{url:string})=>{
    return(
        <div className="moviebanner">
            <img src={props.url} alt="" />
            <div className="shadowoverlay"></div>
        </div>
    )
}
export default MovieBanner