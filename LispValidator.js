function validateLisp(inputStr) {
    const parens = [];
    for (var i = 0; i < inputStr.length; i++) {
        if(inputStr.charAt(i) === "(")
        {
            parens.push("(");
        }
        if(inputStr.charAt(i) === ")")
        {
            if(parens.length > 0)
            {
                parens.pop();

            }else{
                alert("Error");
            }
        }
    }
    if(parens.length> 0 || inputStr.length === 0)
    {
        alert("Error");
    }
    else{
        alert("True");
    }
}