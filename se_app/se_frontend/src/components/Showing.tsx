import { useNavigate } from 'react-router-dom'
import './Upcoming.css'
const Showing = (props: { url: string, title: string, genre: string }) => {
    const nav = useNavigate()
    return (
        <div onClick={()=>nav('/'+props.title.replace(/\s/g,''))}>
            <div className="showing">
                <div className="showingimgwrapper">
                    <img src={props.url} alt="" />
                </div>
                <div className="textcontainer">
                    <h1>{props.title}</h1>
                    <h3>{props.genre}</h3>
                </div>
            </div>
        </div>
    )
}
export default Showing