import React from 'react'
import { useNavigate } from 'react-router-dom'
import { BsCalendar3 } from "react-icons/bs"
import { AppstoreOutlined, HomeOutlined } from '@ant-design/icons';
import { Menu } from 'antd';
export default function Sidebar() {
    const navigate = useNavigate();
    const items = [
        {
            key: '0',
            label: 'DASHBOARD',
            icon: <HomeOutlined />,
        },
        {
            type: 'divider',
        },
        {
            key: 'm1',
            label: 'MASTER',
            icon: <AppstoreOutlined />,
            children: [
                { key: '1.1', label: 'Country' },
                { key: '1.2', label: 'State' },
                { key: '1.3', label: 'City' },
                { key: '1.4', label: 'Guest' },
            ],
        },
        {
            type: 'divider',
        },
        {
            key: 'sub4',
            label: 'TRANSACTION',
            icon: <AppstoreOutlined />,
            children: [
                { key: '9', label: 'Option 9' },
                { key: '10', label: 'Option 10' },
                { key: '11', label: 'Option 11' },
                { key: '12', label: 'Option 12' },
                { key: '13', label: 'Option 13' },
                { key: '14', label: 'Option 14' },
                { key: '15', label: 'Option 15' },
            ],
        },
    ];
    const onClick = e => {
        console.log('click ', e.key);
        switch (e.key) {
            case '0':
                navigate('/dashboard');
                break;
            case '1.1':
                navigate('/country');
                break;
            case '1.2':
                navigate('/state');
                break;
            case '1.3':
                navigate('/city');
                break;
            default:
                break;
        }
    };
    return (
        <>
        <aside>
            {/* <!-- Sidebar --> */}
            <div className="bg-white" id="sidebar-wrapper">
                <div className="sidebar-heading text-center py-2 primary-text fs-5 fw-bold text-uppercase border-bottom"
                    style={{ "text-shadow": "10px 0px 5px #ccc" }}><BsCalendar3 /> MY EVENT</div>
                <div style={{ height: "90vh", "overflow-y": "auto" }}>
                    <Menu
                        onClick={onClick}
                        style={{ width: 225 }}
                        defaultSelectedKeys={['1']}
                        defaultOpenKeys={['sub1']}
                        mode="inline"
                        items={items}
                    />
                </div>
            </div>
            {/* <!-- /#sidebar-wrapper --> */}
            </aside>
        </>
    )
}
