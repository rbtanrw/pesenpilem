import NavBar from "../components/CoolNavBar"
import './Transactions.css'
const Transactions = () => {

    return (
        <div>
            <NavBar />
            <div className="transwrapper">
                <h1 style={{ color: 'white'}}>Transactions:</h1>
                <div className="line" style={{ margin: 0 }} />
                <div className="transitems">
                    <div className="transaction">
                        <div className="id">
                            <h3>ID: TR00</h3>
                        </div>
                        <div className="date">
                            <h3>Date: 2022-12-09 12:20:21.000</h3>
                        </div>
                        <div className="seats">
                            <h3>Seats: C3, C4, C5</h3>
                        </div>
                    </div>
                    <div className="transaction">
                        <div className="id">
                            <h3>ID: TR00</h3>
                        </div>
                        <div className="date">
                            <h3>Date: 2022-12-5 16:20:21.000</h3>
                        </div>
                        <div className="seats">
                            <h3>Seats: A5</h3>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default Transactions