function GetAcceptableExpenses(AcceptableCategories, expenses){
    const ExpensesList = expenses.split("\n")
    let AcceptableExpenseTotals = []
    let venderDate = []
    
    ExpensesList.forEach(expense => {
        const [vender,date,,price,category] = expense.split(',')

        if ( AcceptableCategories.includes(category)){
            venderDate = [date, ": ", vender, " - $"].join('')

            if ( AcceptableExpenseTotals.find(object => object['dateVender'] === venderDate) ){
                UpdatePrice(AcceptableExpenseTotals, venderDate, price )
            }
            else{
                AcceptableExpenseTotals.push({dateVender: venderDate, totalPrice: price })
            }
        }
    })
    return AcceptableExpenseTotals
}

function UpdatePrice(AcceptableExpenseTotals, venderDate, price ){
    AcceptableExpenseTotals.forEach( AcceptableExpenseTotal =>{
        if (AcceptableExpenseTotal['dateVender'] === venderDate){
            AcceptableExpenseTotal['totalPrice'] = parseFloat( price) + parseFloat(AcceptableExpenseTotal['totalPrice'])
            return
        }
    })
}

function GetAcceptableCategories(categories){
    const categoryList = categories.split("\n")
    const AcceptableCategory = []

    for (i = 0; i < categoryList.length; i++){
        const [Category,,IsExpensible] = categoryList[i].split(',');

        if (IsExpensible === "Y" ){
                AcceptableCategory.push(Category)
        }
    }
    return AcceptableCategory
}

// Input Values
const categories = "CFE,Coffee,Y\nFD,Food,Y\nPRS,Personal,N";
const expenses = "Starbucks,3/10/2018,Iced Americano,4.28,CFE\nStarbucks,3/10/2018,Nitro Cold Brew,3.17,CFE\nStarbucks,3/10/2018,Souvineer Mug,8.19,PRS\nStarbucks,3/11/2018,Nitro Cold Brew,3.17,CFE\nHigh Point Market,3/11/2018,Iced Americano,2.75,CFE\nHigh Point Market,3/11/2018,Pastry,2.00,FD\nHigh Point Market,3/11/2018,Gift Card,10.00,PRS";
// Acceptable: 
//------------------------------------------------
//        Starbucks,        3/10/2018,Iced Americano, 4.28,CFE
//        Starbucks,        3/10/2018,Nitro Cold Brew,3.17,CFE
// TOTAL: Starbucks,        3/10/2018,***,            7.45,CFE *** Total
//        Starbucks,        3/11/2018,Nitro Cold Brew,3.17,CFE
// TOTAL: Starbucks,        3/11/2018,Nitro Cold Brew,3.17,CFE *** Total
//        High Point Market,3/11/2018,Iced Americano, 2.75,CFE
//        High Point Market,3/11/2018,Pastry,         2.00,FD
// TOTAL: High Point Market,3/11/2018,***,            4.75,FD  *** Total
// Not Acceptable
//------------------------------------------------
// Starbucks,        3/10/2018,Souvineer Mug, 8.19,PRS
// High Point Market,3/11/2018,Gift Card,    10.00,PRS

const AcceptableExpenses = GetAcceptableExpenses(GetAcceptableCategories(categories), expenses)

AcceptableExpenses.forEach (AcceptableExpense =>{
    console.log([AcceptableExpense['dateVender'], AcceptableExpense['totalPrice'] ].join(''))
})
console.log("Processing complete")

