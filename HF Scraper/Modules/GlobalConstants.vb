Namespace GlobalConstants
    Module GlobalConstants
        Public Const REGEX_YMD_MATCHER As String = "^(2[0-9]{3})[ ,;._/\-\\](0?[1-9]|1[0-2])[ ,;._/\-\\](0?[1-9]|[1-2][0-9]|3[0-1])[ ,;._/\-\\]?$"
        Public Const REGEX_MD_MATCHER As String = "^(0?[1-9]|1[0-2])[ ,;._/\-\\](0?[1-9]|[1-2][0-9]|3[0-1])[ ,;._/\-\\]?$"
        Public Const FORMAT_YMD As String = "yyyy\/MM\/dd"
        Public Const FORMAT_HMS As String = "hh:mm:ss"
        Public Const FORMAT_YMD_HMS As String = "yyyy\/MM\/dd - hh:mm:ss"
    End Module
End Namespace