import React, { useState, useEffect } from 'react'
import { useNavigate } from 'react-router-dom'
import { Tooltip, Button, message } from 'antd';
import { Formik, Form, Field, ErrorMessage, FastField } from 'formik';
import * as Yup from 'yup';
import './Logincompo.css';
import { Login_Process } from '../../../_services/auth/myauth.service';

export default function Logincompo() {
    const navigate = useNavigate();
    const [messageApi, contextHolder] = message.useMessage();
    const initial = { clientcode: '', username: '', password: '' }

    useEffect(() => {
        localStorage.clear();
    }, []);

    const onSubmit = async (values, onSubmitProps) => {
        try {
            const resp1 = await Login_Process(values);
            console.log(resp1.data);
            const loginresp1 = resp1.data;
            if (loginresp1.iSuccess) {
                //save into local storage
                debugger;
                localStorage.setItem('logininfo', JSON.stringify(loginresp1));
                navigate('/dashboard');
            }
            else {
                messageApi.open({
                    type: 'error',
                    content: `error message : ${loginresp1.errors[0] + ""}`,
                });
            }
            onSubmitProps.resetForm();

        } catch (error) {
            debugger;
            var errstr1;
            console.log(error);
            if (error.response.data !== null) {
                errstr1 = error.response.data.errors[0];
                //console.log(errstr1.errors[0]);
            }
            if (error.name = "AxiosError") {
                messageApi.open({
                    type: 'error',
                    content: "Error : " + errstr1 + ":" + error.message + "".trim(),
                });
            }
            else {
                debugger;
                messageApi.open({
                    type: 'error',
                    content: `error message : ${error.messge + ""}  error data : ${error.response.data.errors[0]}`,

                });
            }
        }
        finally {
            onSubmitProps.setSubmitting(false)
        }
    }

    const validationSchemaForm = Yup.object({
        clientcode: Yup.string().required('Clientcode Required.'),
        username: Yup.string().required('Username Required.'),
        password: Yup.string().required('Password Required')
    })
    return (
        <>
            <div className="container">
                <div className="wrapper">
                    <div className="title">
                        <span>SMART EVENT</span>
                    </div>
                    <p className='title_para'>Please enter your details.</p>
                    <div>{contextHolder}</div>
                    <Formik
                        initialValues={initial}
                        validationSchema={validationSchemaForm}
                        onSubmit={onSubmit}
                        enableReinitialize
                        //validateOnMount
                        validateOnChange={true}
                        validateOnBlur={false}
                    >
                        {
                            formik => {
                                return (
                                    <Form>
                                        <div className="row" >
                                            {/* <i className="fas fa-user"></i> */}
                                            <Tooltip placement="top" title="Enter Your Client Code">
                                                <FastField type="text" id="clientcode" name="clientcode"
                                                    placeholder="Enter Your Client Code..."
                                                    autoFocus />
                                            </Tooltip>
                                            <ErrorMessage name='clientcode'>
                                                {(errorMsg) => <div className='formerror'>{errorMsg}</div>}
                                            </ErrorMessage>
                                        </div>
                                        <div className="row">
                                            {/* <i className="fas fa-user"></i> */}
                                            <Tooltip placement="top" title="Enter your Username">
                                                <FastField type="text" id="username" name="username" placeholder="Enter your Username..."
                                                />
                                            </Tooltip>
                                            <ErrorMessage name='username'>
                                                {(errormsg) => <div className='formerror'>{errormsg}</div>}
                                            </ErrorMessage>
                                        </div>
                                        <div className="row">
                                            {/* <i className="fas fa-lock"></i> */}
                                            <Tooltip placement="top" title="Enter your Password">
                                                <FastField type="password" id="password" name="password" placeholder="Enter your Password..."
                                                />
                                            </Tooltip>
                                            <ErrorMessage name='password'>
                                                {(errorMsg) => <div className='formerror'>{errorMsg}</div>}
                                            </ErrorMessage>
                                        </div>
                                        <div className="row button">
                                            <input type='submit' value={formik.isSubmitting ? "Submitting" : "Login"}
                                                disabled={(formik.isSubmitting)}
                                            />
                                        </div>
                                        <div className="signup-link">Create New Account? <a href="#">Signup now</a></div>
                                    </Form>
                                )
                            }
                        }

                    </Formik>
                </div>
            </div>
        </>
    )
}
