import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [url, setUrl] = useState("")
    const [directory, setDirectory] = useState("")
    const handleSubmit = async (e) => {

        e.preventDefault();
        const response = await fetch("https://localhost:7130/Github?url=" + url, {
            mode: "no-cors"
        })
        console.log(response)

        const result = await response.json();
        setDirectory(result)
        console.log('rendering')

    }
    return (
        <>
            <form onSubmit={(e) => handleSubmit(e)}>
                <input type="test" onChange={(e) => setUrl(e.target.value)} placeholder="enter url"></input>
                <button type="submit">Submit</button>
            </form>
            {directory && directory}
        </>
    )
}

export default App;
