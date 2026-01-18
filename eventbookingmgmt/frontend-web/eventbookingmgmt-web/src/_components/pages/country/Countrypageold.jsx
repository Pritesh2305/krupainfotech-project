import React, { useState } from 'react'
import { Card, Table, Input, Button, Modal } from 'antd';
import { PlusCircleOutlined, EditOutlined, DeleteOutlined } from '@ant-design/icons';

export default function Countrypageold() {
  const [searchedText, setSearchedText] = useState("");
  const [loading, setLoading] = useState(false);
  const [isEditing, setIsEditing] = useState(false);
  const [countryDataSource,setcountryDataSource] = useState([]);
  const [countryColumnSource,setcountryColumnSource] = useState([]);

  const data = [
    {
      "rid": 1,
      "citycode": "adi",
      "cityname": "ahmedabad",
      "cityremark1": "city remark 1",
      "cityremark2": "city remark 2"
    },
    {
      "rid": 2,
      "citycode": "mhd",
      "cityname": "mahemdabad",
      "cityremark1": "t1",
      "cityremark2": "t2"
    },
    {
      "rid": 3,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 4,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 5,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 6,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 7,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 8,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 9,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 10,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 11,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 12,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 13,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 14,
      "citycode": "t1",
      "cityname": "b",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 15,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 16,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 17,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 18,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 19,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 20,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 21,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 22,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 23,
      "citycode": "t1",
      "cityname": "c",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 24,
      "citycode": "t1",
      "cityname": "d",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 25,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 26,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 27,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 28,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 29,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 30,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 31,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
    {
      "rid": 32,
      "citycode": "t1",
      "cityname": "test",
      "cityremark1": "t",
      "cityremark2": ""
    },
  ]
  const columns = [{
    title: 'Rid',
    dataIndex: 'rid',
    key: 'rid',
    width: 80,
    fixed: 'left',
    fixed: 'start',
    sorter: (a, b) => a.rid > b.rid
  },
  {
    title: 'Code',
    dataIndex: 'citycode',
    key: 'rid',
    filteredValue: [searchedText],
    onFilter: (value, record) => {
      return String(record.citycode).toLowerCase().includes(value.toLowerCase()) ||
        String(record.rid).toLowerCase().includes(value.toLowerCase()) ||
        String(record.cityname).toLowerCase().includes(value.toLowerCase());
    },
    sorter: (a, b) => a.citycode.localeCompare(b.citycode)
  },
  {
    title: 'Name',
    dataIndex: 'cityname',
    key: 'rid',
    sorter: (a, b) => a.cityname.localeCompare(b.cityname)
  },
  {
    title: 'Remark 1',
    dataIndex: 'cityremark1',
    key: 'rid',
    sorter: (a, b) => a.cityremark1.localeCompare(b.cityremark1)
  },
  {
    title: 'Remark 2',
    dataIndex: 'cityremark2',
    key: 'rid',
    sorter: (a, b) => a.cityremark2.localeCompare(b.cityremark2)
  },
  {
    title: 'Actions',
    key: 'rid',
    width: 80,
    fixed: 'right',
    render: (record) => {
      return (<>
        <EditOutlined style={{ color: 'green', fontSize: '20px', marginRight: 10 }}
          onClick={() => { onEditCountry(record) }}
        />
        <DeleteOutlined style={{ color: 'red', fontSize: '20px' }}
          onClick={() => {
            onDeleteCountry(record)
          }}
        />
      </>)
    }
  }
  ]
  const onEditCountry = (record) => {
    console.log("edit");
    setIsEditing(true);
  }
  const onDeleteCountry = (record) => {
    Modal.confirm({      
      title: 'Are you sure, want to Delete record?',
      okText: 'Yes',
      okType: 'danger',
      onOk: () => {
        alert('Delete');
      }
    })
  }
  return (
    <>
      {/* <Card title="Country Master"  headStyle={{ color: 'blue'}} variant="borderless" ></Card> */}
      <div >
        <Card hoverable size="small" title="COUNTRY INFORMATION"
          styles={{
            header: { color: 'black', backgroundColor: '#FFF8DE' },
          }}
          style={{ height: "90vh", "overflow": "auto" }}
          extra={
            <Button color="primary" variant="solid" icon={<PlusCircleOutlined />}>
              ADD
            </Button>
          }
        >
          <Input.Search placeholder="Serach here.."
            enterButton
            style={{ marginBottom: 10 }}
            onSearch={(value) => {
              setSearchedText(value);
              console.log(searchedText);
            }}
            onChange={(e) => {
              setSearchedText(e.target.value);
            }}
          />
          <Table
            loading={loading}
            size="small"
            // pagination={false}
            pagination={{ pageSize: 20 }}
            dataSource={data}
            columns={columns}
            scroll={{ x: 500, y: 500 }}
            bordered
          >
          </Table>
        </Card>
      </div>
      <div>
        <Modal
          centered
          title="Edit Country"
          open={isEditing}
          onCancel={() => { setIsEditing(false) }}
          onOk={() => { setIsEditing(false) }}
          width={{
            xs: '90%',
            sm: '80%',
            md: '70%',
            lg: '60%',
            xl: '50%',
            xxl: '40%',
          }}
        >
        </Modal>
      </div>
    </>
  )
}
