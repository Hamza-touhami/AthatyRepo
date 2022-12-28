import './App.css';
import Api from './components/api/Api';
import Navbar from './components/navbar/Navbar';

function App() {

  Api.addCategories();
  Api.getCategories(()=>{
    console.log("Get Categs");
  })
  
  return (
    <div>
       <Navbar />
    </div>
  );
}

export default App;
