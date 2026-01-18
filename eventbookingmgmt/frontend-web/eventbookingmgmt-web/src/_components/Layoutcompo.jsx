import React from 'react'
import Sidebar from './common/sidebar/Sidebar'
import Header from './common/header/Header'
import Dashboard from './pages/Dashboard/Dashboard/Dashboard'
import { Outlet } from 'react-router'

export default function Layoutcompo() {
  return (
    <div className="d-flex" id="wrapper">
      <Sidebar />
      <div id="page-content-wrapper">
        <Header />
        {/* <Dashboard /> */}
        <Outlet/>
      </div>
    </div>
  )
}
