import { useContext, useState } from "react"
import { UserCtx } from "../context/UserContext"
import { useNavigate } from "react-router-dom"
import './CoolNavBar.css'
const NavBar = () => {
    const { user, setUser } = useContext(UserCtx)
    const nav = useNavigate()
    const [hide, setHide] = useState(true)
    const handleAccountPress = () => {
        if (hide) {
            setHide(false)
        }
        else {
            setHide(true)
        }
    }
    const handleLogOut = () => {
        setUser({
            ...user,
            username: '',
            password: '',
            email: '',
            seats: []
        })
        nav('/loginregister')
    }
    return (
        <div className="navbar">
            <div className="navbarwrapper">
                <div className="left" style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', gap: 20 }}>
                    <h1 onClick={() => nav('/')} style={{ cursor: 'pointer' }}>PesenPilem.com</h1>
                    {user.username === '' ? <p onClick={() => nav('/loginregister')} style={{cursor:'pointer'}}>Login or Register</p> : <></>}
                </div>
                <div className="right">
                    {user.username === '' ? <></> :
                        <p onClick={handleAccountPress} style={{ cursor: 'pointer' }}>{user.username}</p>
                    }
                </div>
            </div>
            {user.username === '' ? <></> :
                <div className="dropdown" style={hide?{display:'none'}:{display:'flex'}}>
                    <button onClick={()=>nav('/transactions')}>Transactions</button>
                    <button onClick={handleLogOut}>Log Out</button>
                </div>
            }



        </div>
    )
}
export default NavBar;