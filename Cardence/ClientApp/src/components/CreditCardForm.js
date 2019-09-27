import React from 'react';
import axios from 'axios';
import CreditCardResult from'./CreditCardResult';
import './CreditCardForm.css';

class CreditCardForm extends React.Component {

    state={"card":null};

    submitHandler = event => {
        event.preventDefault();
        event.target.className += " was-validated";

        this.postFindSuitableCard()
    }

     postFindSuitableCard = async () => {

        const enquiryMessage = {
            ...this.state
            };

          axios.post('https://localhost:5001/cardenquiry/', enquiryMessage)
            .then((response) => {
               this.handleCardResult(response.data);
            });

    }

    handleCardResult = card => {
        this.setState({"card":card});
    }

    changeHandler = event => {
        this.setState({ [event.target.name]: event.target.value });
    };

    showForm = () => {
        this.setState({"card":null});
    }

    render(){
        if (this.state["card"] === null) {
            return this.renderForm();
        } else {
            return this.renderCardResult(this.state["card"]);
        }
    };


    renderForm = () => {
        return (
            <div className="panel panel-default">
        <form className="creditcardform needs-validation" id="enquiryform" onSubmit={this.submitHandler}>
            <fieldset>
                <label htmlFor="firstname">First name: </label>
                <input
                        id="firstname"
                        name="firstname"
                        onChange={this.changeHandler}
                        placeholder="first name"
                        required />
            </fieldset>
            <fieldset>
                <label htmlFor="lastname">Last name: </label>
                <input id="lastname"
                        name="lastname"
                        onChange={this.changeHandler}
                        type="text"
                        placeholder="last name"
                        required />
            </fieldset>
            <fieldset>
                <label htmlFor="dob">Date of birth: </label>
                <input
                        id="dob"
                        name="dob"
                        onChange={this.changeHandler}
                        placeholder="1980-1-1"
                        type="date"
                        required />
            </fieldset>
            <fieldset>
                <label htmlFor="income">Annual income: </label>
                <input id="income"  
                        name="income"
                        onChange={this.changeHandler}
                        placeholder="15000"
                        type="number"
                        step="any" 
                        required />
            </fieldset>
            <button type="submit">Submit to find the best deal</button>
        </form></div>)
    }

    renderCardResult = card => {
        return <CreditCardResult card={card} showForm={this.showForm} />

            
    };


  
};



export default CreditCardForm;
