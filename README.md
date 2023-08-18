# Weather App
> Provides the user details about the weather condition based on the location


## Table of Contents
- [Lending Club Case Study](#lending-club-case-study)
  - [Table of Contents](#table-of-contents)
  - [General Information](#general-information)
    - [Business Understanding](#business-understanding)
    - [Business Objectives](#business-objectives)
    - [Dataset Used](#dataset-used)
  - [Conclusions](#conclusions)
  - [Technologies Used](#technologies-used)
  - [Acknowledgements](#acknowledgements)
  - [Contact](#contact)
    - [@jaisharma06](#jaisharma06)
    - [@Jithendrian](#jithendrian)

## General Information

### Business Understanding
>You work for a consumer finance company which specialises in lending various types of loans to urban customers. When the company receives a loan application, the company has to make a decision for loan approval based on the applicant’s profile. Two types of risks are associated with the bank’s decision:


>If the applicant is likely to repay the loan, then not approving the loan results in a loss of business to the company


>If the applicant is not likely to repay the loan, i.e. he/she is likely to default, then approving the loan may lead to a financial loss for the company.

### Business Objectives
>This company is the largest online loan marketplace, facilitating personal loans, business loans, and financing of medical procedures. Borrowers can easily access lower interest rate loans through a fast online interface. 


>Like most other lending companies, lending loans to ‘risky’ applicants is the largest source of financial loss (called credit loss). Credit loss is the amount of money lost by the lender when the borrower refuses to pay or runs away with the money owed. In other words, borrowers who default cause the largest amount of loss to the lenders. In this case, the customers labelled as 'charged-off' are the 'defaulters'. 
>If one is able to identify these risky loan applicants, then such loans can be reduced thereby cutting down the amount of credit loss. Identification of such applicants using EDA is the aim of this case study.


>In other words, the company wants to understand the driving factors (or driver variables) behind loan default, i.e. the variables which are strong indicators of default.  The company can utilise this knowledge for its portfolio and risk assessment. 

### Dataset Used
>The data given contains information about past loan applicants and whether they ‘defaulted’ or not. The aim is to identify patterns which indicate if a person is likely to default, which may be used for taking actions such as denying the loan, reducing the amount of loan, lending (to risky applicants) at a higher interest rate, etc.

When a person applies for a loan, there are two types of decisions that could be taken by the company:

1. **Loan accepted**: If the company approves the loan, there are 3 possible scenarios described below:

- **Fully paid**: Applicant has fully paid the loan (the principal and the interest rate)

- **Current**: Applicant is in the process of paying the instalments, i.e. the tenure of the loan is not yet completed. These candidates are not labelled as 'defaulted'.

- **Charged-off**: Applicant has not paid the instalments in due time for a long period of time, i.e. he/she has defaulted on the loan 

2. **Loan rejected**: The company had rejected the loan (because the candidate does not meet their requirements etc.). Since the loan was rejected, there is no transactional history of those applicants with the company and so this data is not available with the company (and thus in this dataset)

## Conclusions
- Higher the interest rate higher charged off ratio
- Higher the annual income higher the loan amount slightly
- Interest rate is increasing with loan amount increase this results in high charged off.
- Mostly applicants take loan for debt consolidation and hence the highest default rate is in the same category
- Surprisingly verified loans has more default rate than unverified default rates.

## Technologies Used
- Python - version 3.11.0
- Matplotlib - version 3.7.2
- Pandas - version 2.0.3
- Seaborn - version 0.12.2

## Acknowledgements
This project was made as an assignment for the Lending Club Case Study problem. Thank you UpGrad for providing us an opportunity to work on this.


## Contact
Created by -

### [@jaisharma06](https://github.com/jaisharma06)</br>
Name - Jai Prakash</br>
Email - [jai.sharma06@live.com](mailto:jai.sharma06@live.com)</br>
Phone - +91-8447490922

### [@Jithendrian](https://github.com/Jithendrian)</br>
Name - Jithendrian Sundaravaradan</br>
Email - [jithendrian@gmail.com](mailto:jithendrian@gmail.com)</br>
Phone - +91-9686831200</br>

*Alternate github repository link - [https://github.com/Jithendrian/MLProjects](https://github.com/Jithendrian/MLProjects)*</br>
*Presentation Link - [Lending Club Case Study](https://github.com/jaisharma06/EPGP-Projects/blob/main/LendingClubCaseStudy/Lending_Club_Case_Study.pdf)*

feel free to contact us :smiley:!