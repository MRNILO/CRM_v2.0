function cb_impedimentoChange(s, e) {

    var valor = s.GetValue();

    if (valor == 1) {
        Bcb_impedimentos.SetEnabled(true);
        Bcb_preguntas.SetEnabled(true);
    } else {
        Bcb_impedimentos.SetEnabled(false);
        Bcb_preguntas.SetEnabled(false);
    }
    
}

function Bcb_impedimentosChange(s, e) {

}