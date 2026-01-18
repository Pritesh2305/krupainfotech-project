import { BrowserRouter, Navigate, Route, Routes } from 'react-router';
import Logincompo from './_components/auth/login/Logincompo';
import { PrivateRoute } from './_privateRoute/privateRoute';
import Dashboard from './_components/pages/Dashboard/Dashboard/Dashboard';
import Countrypage from './_components/pages/country/Countrypage';
import Citypage from './_components/pages/city/Citypage';
import Statepage from './_components/pages/state/Statepage';
import './app.css';
function App() {
  return (
    <>

      <BrowserRouter>
        <Routes>
          <Route path='/' element={<Logincompo />} />
          <Route path='/auth/login' element={<Logincompo />} />
          <Route path='/login' element={<Logincompo />} />
          <Route path="/" element={<PrivateRoute />}>
            <Route path="/dashboard" element={<Dashboard />}></Route>
            <Route path="/country" element={<Countrypage />}></Route>
            <Route path="/state" element={<Statepage />}></Route>
            <Route path="/city" element={<Citypage />}></Route>
          </Route>
          <Route path="/*" element={<Navigate to="/auth/login"></Navigate>} />
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
