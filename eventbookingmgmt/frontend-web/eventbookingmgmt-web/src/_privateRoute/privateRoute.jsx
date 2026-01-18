import React from 'react'
import { Navigate, Outlet } from 'react-router-dom'
import Layoutcompo from '../_components/Layoutcompo';


export const PrivateRoute = () => {
    return (
        <>        
            {                       
                localStorage.getItem("logininfo") ? <Layoutcompo><Outlet /></Layoutcompo> : <Navigate to={'/auth/login'} />
                
                //localStorage.getItem("userDetails") ? <Layoutcompo><Outlet /></Layoutcompo> : <Layoutcompo><Outlet /></Layoutcompo> 
            }

        </>
    )

    //return localStorage.getItem("userDetails") ? <Layoutcompo><Outlet/></Layoutcompo> : <Navigate to={'/auth/login'} />;

}