import { Formik, Form, Field, ErrorMessage, FastField } from 'formik';
import React, { useState } from 'react';
import { Button, Alert, Tooltip } from 'antd';
import * as Yup from 'yup';
import { userService } from '../../../_services/auth/auth.service';
import './Logincompo.css';

export default function Loginnewcompo() {
  const [formVal, setformVal] = useState(null)
  const initial = { clientcode: '', username: '', password: '' }
  const loaddata = { clientcode: 'event', username: 'aa', password: 'fff' }
  const onSubmit = (values, onSubmitProps) => {
    debugger;
    console.log('Form Data', values);
    console.log('onSubmitProps Data', onSubmitProps);
    onSubmitProps.setSubmitting(false)
    onSubmitProps.resetForm();
  }

  const validateForm = values => {
    let errors = {}
    if (!values.clientcode) {
      errors.clientcode = 'Clientcode Required.'
    } // if check other validation then else if(values.clientcode.){}

    if (!values.username) {
      errors.username = 'Username Required.'
    }

    if (!values.password) {
      errors.password = 'Password Required.'
    }
    return errors
  }

  const validationSchemaForm = Yup.object({
    clientcode: Yup.string().required('Clientcode Required.'),
    username: Yup.string().required('Username Required.'),
    password: Yup.string().required('Password Required')
  })

  const validateclientcode = value => {
    let error
    if ((value.length) <= 2) {
      error = "clientcode must grether then 3"
    } else if (value != "event") {
      error = "Invalid clientcode."
    }

    return error;
  }

  // const formik = useFormik({
  //   initialValues: initial,
  //   onSubmit: onSubmit,
  //   //validate: validateForm,
  //   validationSchema: validationSchemaForm
  // })

  //console.log('Form Values',formik.values);
  //console.log('Form Errors', formik.errors);
  //console.log('render');


  return (
    <div className="container">
      <div className="wrapper">
        <div className="title">
          <span>SMART EVENT</span>
        </div>
        <p className='title_para'>Please enter your details.</p>
        <Formik
          initialValues={formVal || initial}
          validationSchema={validationSchemaForm}
          onSubmit={onSubmit}
          enableReinitialize
        // validateOnMount
        //validateOnChange={false}
        //validateOnBlur={false}
        >
          {
            formik => {
              //console.log('formik props : ', formik);
              return (
                <Form>
                  <div className="row" >
                    {/* <i className="fas fa-user"></i> */}
                    <Tooltip placement="top" title="Enter your Client Code">
                      <FastField type="text" id="clientcode" name="clientcode" validate={validateclientcode}
                        placeholder="Enter your Client Code..."
                        autoFocus />
                    </Tooltip>
                    {/* {formik.touched.clientcode && formik.errors.clientcode ? <div className='formerror'>{formik.errors.clientcode}</div> : null} */}
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
                    {/* {formik.touched.username && formik.errors.username ? <div className='formerror'>{formik.errors.username}</div> : null} */}
                    <ErrorMessage name='username'>
                      {(errormsg) => <div className='formerror'>{errormsg}</div>}
                    </ErrorMessage>
                  </div>
                  <div className="row">
                    {/* <i className="fas fa-lock"></i> */}
                    <Tooltip placement="top" title="Enter your Password">
                      <FastField type="password" id="password" name="password" placeholder="Enter your Password..."
                      />
                      {/* <Field as='select'></Field> */}
                    </Tooltip>
                    {/* {formik.touched.password && formik.errors.password ? <div className='formerror'>{formik.errors.password}</div> : null} */}
                    <ErrorMessage name='password'>
                      {(errorMsg) => <div className='formerror'>{errorMsg}</div>}
                    </ErrorMessage>
                  </div>
                  {/* <div className="pass"><a href="#">Forgot password?</a></div> */}
                  {/* <div className="row button"> */}
                  <div>
                    <input type='submit' value="Login"
                      // disabled={!( formik.dirty && formik.isValid)} 
                      //disabled={( !formik.isValid || formik.isSubmitting)}
                      disabled={(formik.isSubmitting)}
                    />
                  </div>

                  {/* {
                    console.log(formik.values.clientcode)
                  } */}
                  <div >
                    <input type="button" value="Loaddata" style={{ marginBottom: "10px" }}
                      onClick={() => setformVal(loaddata)}
                    ></input>
                    <input type="button" value="CodeValidate" style={{ marginBottom: "10px" }}
                      onClick={() => formik.validateField('clientcode')}
                    ></input>
                    {/* <input type="button" value="Validate All" 
                    onClick={() => formik.validateForm()}></input> */}
                    <input type="button" value="Validate All"
                      onClick={() => formik.setTouched({
                        clientcode: true,
                        username: true,
                        password: true
                      })}></input>
                  </div>
                  <div className="signup-link">Create New Account? <a href="#">Signup now</a></div>
                </Form>
              )
            }
          }

        </Formik>
      </div>
    </div>
  )

  // <Field component="select"></Field>
  {/* <Field as='select'></Field> */ }
  {/* <Field components='select'></Field> */ }
  // return (
  //   <>
  //     <section style={{ display: "block" }}>
  //       <form onSubmit={formik.handleSubmit}>
  //         <label htmlFor='username'>Username</label>
  //         <input type="text" id="username" name="username" onChange={formik.handleChange} value={formik.values.username}></input>
  //         <label htmlFor='password'>Password</label>
  //         <input type="password" id="password" name="password" onChange={formik.handleChange} value={formik.values.password}></input>
  //         <button className='btn btn-primary' type="submit">Submit</button>
  //       </form>
  //     </section>
  //   </>
  // )
}
