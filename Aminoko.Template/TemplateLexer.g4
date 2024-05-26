lexer grammar TemplateLexer;

TEXT
  : [#&] ~[a-zA-Z0-9_]
  | ~[&#]
  ;

STATEMENT_START
  : STATEMENT_PREFIX -> pushMode(IN_STATEMENT), skip
  ;

SECTION_START
  : SECTION_PREFIX -> pushMode(IN_SECTION), skip
  ;

mode IN_SECTION;

  SECTION_FRONT
    : F R O N T NEWLINE -> popMode
    ;

  SECTION_BACK
    : B A C K NEWLINE -> popMode
    ;

  SECTION_STATEMENTS 
    : S T A T E M E N T S NEWLINE+ -> popMode
    ;

mode IN_STATEMENT;

  STATEMENT_METHOD_TRANSLATE
    : T R A N S L A T E OPEN_BRACKET -> pushMode(IN_STATEMENT_METHOD)
    ;
    
  STATEMENT_METHOD_AUDIO
    : A U D I O OPEN_BRACKET -> pushMode(IN_STATEMENT_METHOD)
    ;

  STATEMENT_METHOD_QUERY
    : Q U E R Y OPEN_BRACKET -> pushMode(IN_STATEMENT_METHOD)
    ;

  STATEMENT_METHOD_IMAGE
    : I M A G E OPEN_BRACKET -> pushMode(IN_STATEMENT_METHOD)
    ;

  STATEMENT_WORD
    : W O R D -> popMode
    ;

  STATEMENT_SENTENCE
    : S E N T E N C E -> popMode
    ;
    
  STATEMENT_IMAGE
    : I M A G E -> popMode
    ;

  STATEMENT_DEFINITION
    : D E F I N I T I O N -> popMode
    ;

  STATEMENT_METHOD_STATEMENT_DECLARATION          
    : [a-zA-Z0-9_]+ OPEN_BRACKET -> pushMode(IN_STATEMENT_METHOD)
    ;

  STATEMENT
    : [a-zA-Z0-9_]+ -> popMode
    ;

mode IN_STATEMENT_METHOD;

  STATEMENT_METHOD_TERMINATION
    : CLOSE_BRACKET -> popMode, popMode
    ;

  STRING
    : [&] ~[a-zA-Z0-9_]
    | ~[&]
    ;
    
  STATEMENT_START_NESTED
    : STATEMENT_PREFIX -> pushMode(IN_STATEMENT), skip
    ;

fragment NEWLINE : [ \t]* '\r'? '\n';
fragment STATEMENT_PREFIX: '&';
fragment SECTION_PREFIX: '#';
fragment OPEN_BRACKET: '(';
fragment CLOSE_BRACKET: ')';

fragment A: [Aa];
fragment B: [Bb];
fragment C: [Cc];
fragment D: [Dd];
fragment E: [Ee];
fragment F: [Ff];
fragment G: [Gg];
fragment H: [Hh];
fragment I: [Ii];
fragment J: [Jj];
fragment K: [Kk];
fragment L: [Ll];
fragment M: [Mm];
fragment N: [Nn];
fragment O: [Oo];
fragment P: [Pp];
fragment Q: [Qq];
fragment R: [Rr];
fragment S: [Ss];
fragment T: [Tt];
fragment U: [Uu];
fragment V: [Vv];
fragment W: [Ww];
fragment X: [Xx];
fragment Y: [Yy];
fragment Z: [Zz];