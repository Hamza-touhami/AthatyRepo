import './App.css';
import Api from './components/api/Api';
import Sidebar from './components/sidebar/Sidebar';

function App() {

  Api.addCategories();
  Api.getCategories(()=>{
    console.log("Get Categs");
  })
  
  return (
       <Sidebar />
  );
}

export default App;
