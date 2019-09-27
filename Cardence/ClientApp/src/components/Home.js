import React, { Component } from 'react';
import CreditCardForm from './CreditCardForm';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello and welcome to <strong>Cardence</strong></h1>
        <p>
                <strong>Would you like to know the best credit card deal available for you?</strong><br />
                Just take 1 minute to fill out the form below and we find it for you:
        </p>

        <CreditCardForm />

      </div>
    );
  }
}
