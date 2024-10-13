import { useContext, useEffect, useState } from 'react'
import './LogReg.css'
import { useNavigate } from 'react-router-dom'
import { UserCtx } from '../context/UserContext'
const LogReg = () => {
    const nav = useNavigate()
    const [loginPosition, setLoginPosition] = useState(0)
    const [logEmail, setLogEmail] = useState("")
    const [logPass, setLogPass] = useState("")

    const [name, setName] = useState("")
    const [regEmail, setRegEmail] = useState("")
    const [regPass, setRegPass] = useState("")
    const [check, setCheck] = useState(false)

    const { user, setUser } = useContext(UserCtx)
    const [data, setData] = useState(undefined);

    const [valid, setValid] = useState(true)
    // const fetchLoginData = async () => {
    //     try {
    //         const url = `https://localhost:7059/api/Customers/${logEmail}, ${logPass}`;
    //         const response = await fetch(url,{
    //             method:'GET',
    //         })
    //         const result =  await response.json()
    //         console.log(result)
    //     }
    //     catch(error){
    //         console.log(error)
    //     }
    // }
    const moveDown = () => {
        if (loginPosition != 0) {
            setLoginPosition(loginPosition + 360)
        }
    }
    const moveUp = () => {
        if (loginPosition == 0) {
            setLoginPosition(loginPosition - 360)
        }
    }
    const registButton = () => {
        var validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;

        if (name != '' && regPass != '' && check && regEmail.match(validRegex)) {
            setUser({
                ...user,
                username: name,
                password: regPass,
                email: regEmail,
            })
            nav('/')
        }
        else{
            console.log("ass")
            setValid(false)
        }
    }
    // useEffect(()=>{

    // })
    return (
        <div className="logregpage">
            <header>
                <a href="" onClick={() => nav('/')}> Home</a>
                <a href="" style={{ color: 'orange' }} >Login or Register</a>
            </header>
            <div className="logreg" >

                <div className="signupwrapper" onClick={moveDown}>
                    <h1 style={{ marginTop: 25, fontSize: 40 }}>PesenPilem.com</h1>
                    <h3>Sign-Up</h3>
                    <input type="text" placeholder="Full Name" onChange={(e) => setName(e.target.value)} style={!valid?{borderWidth:1, borderColor:'red'}:{border:'none'}}/>
                    <input type="text" placeholder="Email Address" onChange={(e) => setRegEmail(e.target.value)} style={!valid?{borderWidth:1, borderColor:'red'}:{border:'none'}}/>
                    <input type="text" placeholder="Password" id="pass" onChange={(e) => setRegPass(e.target.value)}style={!valid?{borderWidth:1, borderColor:'red'}:{border:'none'}}/>
                    <div className="checkbox"><input type="checkbox" onChange={() => { check == false ? setCheck(true) : setCheck(false) }}/><label htmlFor="check" style={!valid?{color:'red'}:{}}>I accept all terms &conditions </label></div>

                    <button onClick={() => {registButton()}}>Sign-Up</button>
                    <h3 style={{ marginTop: 20, marginBottom: 5 }}>Have an account? Login down here</h3>
                </div>
                <div className="logincontainer" onClick={moveUp} style={{ transform: `translateY(${loginPosition}px)` }}>
                    <div className="loginwrapper">
                        <h3 style={{ padding: 10 }}>Login</h3>
                        <input type="text" placeholder="Email Address" onChange={(e) => setLogEmail(encodeURIComponent(e.target.value))} />
                        <input type="password" placeholder="Password" onChange={(e) => setLogPass(e.target.value)} />
                        <button>Login</button>
                        <h4>Click outside to close</h4>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default LogReg