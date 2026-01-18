import React, { useEffect, useState } from 'react'
import Constantval from '../../../_helpers/Constantval';
import { Card, Table, Input, Button, Modal } from 'antd';
import { PlusCircleOutlined, EditOutlined, DeleteOutlined } from '@ant-design/icons';


export default function Countrypage() {
    const [searchedText, setSearchedText] = useState("");
    const [loading, setLoading] = useState(false);
    const [isEditing, setIsEditing] = useState(false);
    const [countryDataSource, setcountryDataSource] = useState([]);
    const [countryColumnSource, setcountryColumnSource] = useState([]);

    useEffect(() => {

    })

    return (
        <>
            <section>
                <Card hoverable size="small" title="COUNTRY INFORMATION"
                    styles={{
                        header: { color: 'black', backgroundColor: '#FFF8DE' },
                    }}
                    style={{ height: "90vh", "overflow": "auto" }}
                    extra={
                        <Button color="primary" variant="solid" icon={<PlusCircleOutlined />}>
                            ADD
                        </Button>
                    }>
                    <section>
                        <Input.Search placeholder="Serach here.."
                            enterButton
                            style={{ marginBottom: 10 }}
                            onSearch={(value) => {
                                setSearchedText(value);
                                console.log(searchedText);
                            }}
                            onChange={(e) => {
                                setSearchedText(e.target.value);
                            }} />
                    </section>
                    <section>
                        <Table
                            bordered
                            loading={loading}
                            size="small"
                            pagination={{ pageSize: Constantval.PAGE_RECORD_SIZE }}
                            scroll={{ x: 500, y: 500 }}
                        >

                        </Table>
                    </section>


                </Card>

            </section>

        </>
    )
}
