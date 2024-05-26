parser grammar TemplateParser;

options {
  tokenVocab=TemplateLexer;
}

template
  : statements front back
  ;

statements
  : SECTION_STATEMENTS statementsBody
  ;

front
  : SECTION_FRONT body
  ;

back
  : SECTION_BACK body EOF
  ;

body
  : blockExpression+
  ;

statementsBody
  : inlineTextStatementDeclaration+
  ;

inlineTextStatementDeclaration  
  : inlineStatementDeclaration
  | inlineText
  ;

inlineStatementDeclaration
  : STATEMENT_METHOD_STATEMENT_DECLARATION statementMethodParameters STATEMENT_METHOD_TERMINATION
  ;
  
inlineTextExpressions
  : inlineTextExpression+
  ;

inlineTextExpression
  : inlineExpression
  | inlineText
  ;

inlineExpression
  : inlineStatementConstant
  | inlineStatement
  | inlineStatementMethod         
  ;

blockExpression
  : blockStatementConstant
  | blockStatementMethod
  | blockText
  ;

blockText
  : inlineTextExpressions
  ;

blockStatementConstant
  : STATEMENT_IMAGE                #blockStatementImage
  | STATEMENT_DEFINITION           #blockStatementDefinition
  ;

statementMethodParameters
  : statementMethodParameter+
  ;

statementMethodParameter
  : inlineString
  | inlineExpression
  ;

inlineStatement
  : STATEMENT
  ;

inlineStatementConstant
  : STATEMENT_WORD       #inlineStatementWord
  | STATEMENT_SENTENCE   #inlineStatementSentence
  ;

inlineStatementMethod
  : STATEMENT_METHOD_TRANSLATE statementMethodParameters STATEMENT_METHOD_TERMINATION   #inlineStatementMethodTranslate
  | STATEMENT_METHOD_QUERY statementMethodParameters STATEMENT_METHOD_TERMINATION       #inlineStatementMethodQuery  
  ;
  
inlineText
  : TEXT+
  ;

inlineString
  : STRING+
  ;

blockStatementMethod
  : STATEMENT_METHOD_AUDIO statementMethodParameters STATEMENT_METHOD_TERMINATION   #blockStatementMethodAudio
  | STATEMENT_METHOD_IMAGE statementMethodParameters STATEMENT_METHOD_TERMINATION   #blockStatementMethodImage
  ;