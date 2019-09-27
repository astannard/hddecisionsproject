import React from 'react';

const CreditCardResult = ({card,showForm} ) => {
    debugger;
    function getResultBody (card, cardDisplay, cardAPR, cardPromo) {
         if (card !== "None") {
            return(<div>
            <p>Thanks for taking the time fill out the form, we have reviewed your details and have found the following card best suited to you:</p>
                <h3>{cardDisplay}</h3>
                <h4>Offering a very reasonable {cardAPR}</h4>
                <p>{cardPromo}</p>
        </div>)
        } else {
            return (<div>
                <p>Thanks for taking the time fill out the form, unfortunatley: {cardDisplay}</p>
                </div>)
        }
    };

    return (
        <div className="card">
            <div className="card-body">
                {getResultBody(card.card, card.cardDisplay, card.cardAPR, card.cardPromo)}
                <button onClick={showForm}>back to form:</button>
            </div>
        </div>
   );    
};

export default CreditCardResult;