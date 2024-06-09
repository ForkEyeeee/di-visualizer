import { useState } from 'react';
import './App.css';

function App() {
    const [url, setUrl] = useState("")

    const handleSubmit = async (e) => {
        e.preventDefault();
        await fetch("https://localhost:7130/DependencyInjection/?url=" + url)
    }
    return (
        <>
            <form onSubmit={(e) => handleSubmit(e)}>
                <input type="test" onChange={(e) => setUrl(e.target.value)} placeholder="enter url"></input>
                <button type="submit">Submit</button>
            </form>
        </>
    )
}

export default App;
