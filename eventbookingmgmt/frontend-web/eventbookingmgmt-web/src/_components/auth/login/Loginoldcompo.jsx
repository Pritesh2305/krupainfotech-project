import { useFormik, ErrorMessage } from 'formik';
import React from 'react';
import { Button, Alert, Tooltip } from 'antd';
import * as Yup from 'yup';
import { userService } from '../../../_services/auth/auth.service';
import './Logincompo.css';

export default function Loginoldcompo() {

  const initial = { clientcode: '', username: '', password: '' }
  const onSubmit = values => { console.log('Form Data', values); }
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

  const formik = useFormik({
    initialValues: initial,
    onSubmit: onSubmit,
    //validate: validateForm,
    validationSchema: validationSchemaForm
  })

  //console.log('Form Values',formik.values);
  console.log('Form Errors', formik.errors);
  return (
    <div className="container">
      <div className="wrapper">
        <div className="title">
          <span>SMART EVENT</span>
        </div>
        <p className='title_para'>Please enter your details.</p>

        <form onSubmit={formik.handleSubmit}>
          <div className="row">
            {/* <i className="fas fa-user"></i> */}
            <Tooltip placement="topLeft" title="Enter your Client Code">
              <input type="text" id="clientcode" name="clientcode" placeholder="Enter your Client Code..."
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                value={formik.values.clientcode}
                required autoFocus />
            </Tooltip>
            {formik.touched.clientcode && formik.errors.clientcode ? <div className='formerror'>{formik.errors.clientcode}</div> : null}
            {/* <ErrorMessage name='clientcode' /> */}
          </div>
          <div className="row">
            {/* <i className="fas fa-user"></i> */}
            <Tooltip placement="topLeft" title="Enter your Username">
              <input type="text" id="username" name="username" placeholder="Enter your Username..."
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                value={formik.values.username}
                required />
            </Tooltip>
            {formik.touched.username && formik.errors.username ? <div className='formerror'>{formik.errors.username}</div> : null}
            {/* <ErrorMessage name='username' /> */}
          </div>
          <div className="row">
            {/* <i className="fas fa-lock"></i> */}
            <Tooltip placement="topLeft" title="Enter your Password">
              <input type="password" id="password" name="password" placeholder="Enter your Password..."
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                value={formik.values.password}
                required />
            </Tooltip>
            {formik.touched.password && formik.errors.password ? <div className='formerror'>{formik.errors.password}</div> : null}
            {/* <ErrorMessage name='password' /> */}
          </div>
          {/* <div className="pass"><a href="#">Forgot password?</a></div> */}
          <div className="row button">
            <input type='submit' value="Login" />
          </div>
          <div className="signup-link">Create New Account? <a href="#">Signup now</a></div>
        </form>
        {/* </Formik> */}
      </div>
    </div>
  )  
}
