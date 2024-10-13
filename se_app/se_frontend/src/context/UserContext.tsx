import { useState,createContext} from "react"

export const UserCtx = createContext<any>("")
const UserProvider = (props:any)=>{
    const [user, setUser]=useState({
        username:'',
        password:'',
        email:'',
        seats:[]
    })
    const providerValue = {
        user,setUser
    }
    return(
        <UserCtx.Provider value={providerValue}>
            {props.children}
        </UserCtx.Provider>
    )
}
export default UserProvider