<?xml version='1.0' encoding='Unicode'?>
<!--
Description: autogenerated XML stylesheet to translate .RESX file
Author: George Birbilis / Zoomicon (www.zoomicon.com)
Version: 20080118
-->

<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='2.0'>
<xsl:output method='xml' version='1.0' encoding='UTF-8' indent='yes'/>

<xsl:template name='root' match='/root'>
<root>
 <xsl:apply-templates/>

</root>
</xsl:template>

<xsl:template match='data'>
 <data>
  <xsl:copy-of select='@*'/>
  <value>
<xsl:if test='@name="mnuAbout.Text" or value/text()="&amp;About..."'>&amp;Acerca…</xsl:if>
<xsl:if test='@name="actionShowAbout.Text" or value/text()="&amp;About..."'>&amp;Sobre…</xsl:if>
<xsl:if test='@name="btnAddSubtitle.Text" or value/text()="&amp;Add subtitle"'>&amp;Adicionar legenda</xsl:if>
<xsl:if test='@name="mnuImportAudio.Text" or value/text()="&amp;Audio"'>&amp;Audio</xsl:if>
<xsl:if test='@name="actionAuthoringMode.Text" or value/text()="&amp;Authoring mode"'>&amp;Modo de Gravação</xsl:if>
<xsl:if test='@name="mnuAuthoringMode.Text" or value/text()="&amp;Authoring mode"'>&amp;Modo de Gravação</xsl:if>
<xsl:if test='@name="actionOpenActivityBrowse.Text" or value/text()="&amp;Browse..."'>&amp;Procurar...</xsl:if>
<xsl:if test='@name="actionImportVideoBrowse.Text" or value/text()="&amp;Browse..."'>&amp;Procurar...</xsl:if>
<xsl:if test='@name="actionImportAudioBrowse.Text" or value/text()="&amp;Browse..."'>&amp;Procurar...</xsl:if>
<xsl:if test='@name="actionImportSubtitlesBrowse.Text" or value/text()="&amp;Browse..."'>&amp;Procurar...</xsl:if>
<xsl:if test='@name="actionImportDocumentBrowse.Text" or value/text()="&amp;Browse..."'>&amp;Procurar...</xsl:if>
<xsl:if test='@name="actionImportPackedActivity.Text" or value/text()="&amp;Browse..."'>&amp;Procurar...</xsl:if>
<xsl:if test='@name="BrowseToolStripMenuItem4.Text" or value/text()="&amp;Browse..."'>&amp;Procurar...</xsl:if>
<xsl:if test='@name="BrowseToolStripMenuItem.Text" or value/text()="&amp;Browse..."'>&amp;Procurar...</xsl:if>
<xsl:if test='@name="BrowseToolStripMenuItem1.Text" or value/text()="&amp;Browse..."'>&amp;Procurar...</xsl:if>
<xsl:if test='@name="BrowseToolStripMenuItem2.Text" or value/text()="&amp;Browse..."'>&amp;Procurar...</xsl:if>
<xsl:if test='@name="BrowseToolStripMenuItem3.Text" or value/text()="&amp;Browse..."'>&amp;Procurar...</xsl:if>
<xsl:if test='@name="ToolStripMenuItem4.Text" or value/text()="&amp;Browse..."'>&amp;Procurar...</xsl:if>
<xsl:if test='@name="actionClearMRU.Text" or value/text()="&amp;Clear Most Recently Used lists"'>&amp;Apagar listas mais recentes</xsl:if>
<xsl:if test='@name="mnuClearMRU.Text" or value/text()="&amp;Clear Most Recently Used lists"'>&amp;Apagar listas mais recentes</xsl:if>
<xsl:if test='@name="actionCloseActivity.Text" or value/text()="&amp;Close"'>&amp;Fechar</xsl:if>
<xsl:if test='@name="mnuCloseActivity.Text" or value/text()="&amp;Close"'>&amp;Fechar</xsl:if>
<xsl:if test='@name="mnuImportDocument.Text" or value/text()="&amp;Document"'>&amp;Documento</xsl:if>
<xsl:if test='@name="actionExportDocument.Text" or value/text()="&amp;Document..."'>&amp;Documento…</xsl:if>
<xsl:if test='@name="DocumentToolStripMenuItem.Text" or value/text()="&amp;Document..."'>&amp;Documento…</xsl:if>
<xsl:if test='@name="STR_ENCODING" or value/text()="&amp;Encoding:"'>&amp;Codificação:</xsl:if>
<xsl:if test='@name="dlgImportDocument.EncodingLabel" or value/text()="&amp;Encoding:"'>&amp;Codificação:</xsl:if>
<xsl:if test='@name="dlgImportSubtitles.EncodingLabel" or value/text()="&amp;Encoding:"'>&amp;Codificação:</xsl:if>
<xsl:if test='@name="dlgExportSubtitles.EncodingLabel" or value/text()="&amp;Encoding:"'>&amp;Codificação:</xsl:if>
<xsl:if test='@name="mnuExit.Text" or value/text()="&amp;Exit"'>&amp;Fechar</xsl:if>
<xsl:if test='@name="actionExit.Text" or value/text()="&amp;Exit"'>&amp;Sair</xsl:if>
<xsl:if test='@name="mnuExport.Text" or value/text()="&amp;Export"'>&amp;Exportar</xsl:if>
<xsl:if test='@name="mnuFile.Text" or value/text()="&amp;File"'>&amp;Ficheiro</xsl:if>
<xsl:if test='@name="mnuHelp.Text" or value/text()="&amp;Help"'>&amp;Ajuda</xsl:if>
<xsl:if test='@name="mnuImport.Text" or value/text()="&amp;Import"'>&amp;Importar</xsl:if>
<xsl:if test='@name="actionNewActivity.Text" or value/text()="&amp;New activity..."'>&amp;Nova actividade…</xsl:if>
<xsl:if test='@name="mnuNewActivity.Text" or value/text()="&amp;New activity..."'>&amp;Nova actividade…</xsl:if>
<xsl:if test='@name="mnuOpenActivity.Text" or value/text()="&amp;Open activity"'>&amp;Abrir Actividade</xsl:if>
<xsl:if test='@name="mnuOptions.Text" or value/text()="&amp;Options"'>&amp;Opções</xsl:if>
<xsl:if test='@name="actionExportPackedActivity.Text" or value/text()="&amp;Packed Activity..."'>&amp;Actividade Compactada…</xsl:if>
<xsl:if test='@name="ToolStripMenuItem2.Text" or value/text()="&amp;Packed Activity..."'>&amp;Actividade Compactada…</xsl:if>
<xsl:if test='@name="mnuImportPackedActivity.Text" or value/text()="&amp;Packed Activity..."'>&amp;Actividade Compactada…</xsl:if>
<xsl:if test='@name="actionPrint.Text" or value/text()="&amp;Print..."'>&amp;Imprimir...</xsl:if>
<xsl:if test='@name="mnuPrint.Text" or value/text()="&amp;Print..."'>&amp;Imprimir...</xsl:if>
<xsl:if test='@name="btnRemoveSubtitle.Text" or value/text()="&amp;Remove subtitle"'>&amp;Eliminar legenda</xsl:if>
<xsl:if test='@name="actionSaveActivity.Text" or value/text()="&amp;Save all"'>&amp;Guardar tudo</xsl:if>
<xsl:if test='@name="mnuSaveActivity.Text" or value/text()="&amp;Save all"'>&amp;Guardar tudo</xsl:if>
<xsl:if test='@name="actionSendFeedback.Text" or value/text()="&amp;Send feedback"'>&amp;Enviar feedback</xsl:if>
<xsl:if test='@name="mnuSendFeedback.Text" or value/text()="&amp;Send feedback"'>&amp;Enviar feedback</xsl:if>
<xsl:if test='@name="mnuImportSubtitles.Text" or value/text()="&amp;Subtitles"'>&amp;Legendas</xsl:if>
<xsl:if test='@name="actionExportSubtitles.Text" or value/text()="&amp;Subtitles..."'>&amp;Legendas…</xsl:if>
<xsl:if test='@name="SubtitlesToolStripMenuItem1.Text" or value/text()="&amp;Subtitles..."'>&amp;Legendas…</xsl:if>
<xsl:if test='@name="mnuImportVideo.Text" or value/text()="&amp;Video"'>&amp;Vídeo</xsl:if>
<xsl:if test='@name="STR_ACTIVITY_FOLDER_EXISTS" or value/text()="Activity folder already exists"'>A Pasta da Actividade já existe</xsl:if>
<xsl:if test='@name="STR_ACTIVITY_MODIFIED" or value/text()="Activity has been modified. Do you want to save before closing?"'>A Actividade foi modificada. Deseja guardar as alterações efectuadadas antes de sair da aplicação?</xsl:if>
<xsl:if test='@name="dlgImportAudio.Filter" or value/text()="Audio files (WAV, AU, MP3)|*.wav;*.au;*.mp3|Wave files (WAV)|*.wav|AU files|*.au|MP3 files|*.mp3"'>Ficheiros audio (WAV, AU, MP3)|*.wav;*.au;*.mp3|Ficherios Wave (WAV)|*.wav|Ficheiros AU|*.au|Ficheiros MP3|*.mp3</xsl:if>
<xsl:if test='@name="STR_AUTHORING" or value/text()="Authoring"'>Gravação</xsl:if>
<xsl:if test='@name="actionClearMRU.Hint" or value/text()="Clear Most Recently Used lists"'>Apagar listas mais recentes</xsl:if>
<xsl:if test='@name="actionCloseActivity.Hint" or value/text()="Close activity"'>Fechar Actividade</xsl:if>
<xsl:if test='@name="STR_COMMENT" or value/text()="Comment"'>Comentário</xsl:if>
<xsl:if test='@name="STR_PACK_ACTIVITY_FOLDER_FAILED" or value/text()="Could not pack activity folder"'>Não conseguiu compactar a pasta de actividade</xsl:if>
<xsl:if test='@name="STR_UNPACK_FAILED" or value/text()="Could not unpack activity file"'>Não conseguiu descompactar o ficheiro da actividade</xsl:if>
<xsl:if test='@name="STR_LOAD_FILE_FAILED" or value/text()="Couldn&apos;t load file"'>Não conseguiu carregar o ficheiro</xsl:if>
<xsl:if test='@name="STR_OPEN_URL_FAILED" or value/text()="Couldn&apos;t open network address (URL)"'>Não conseguiu abrir o endereço de Internet (URL)</xsl:if>
<xsl:if test='@name="STR_SAVE_FILE_FAILED" or value/text()="Couldn&apos;t save file"'>Não conseguiu guardar o ficheiro</xsl:if>
<xsl:if test='@name="STR_FILE_OPEN_DIALOG_FAILED" or value/text()="Couldn&apos;t show file open dialog"'>Não conseguiu abrir o ficheiro abrir diálogo</xsl:if>
<xsl:if test='@name="STR_FILE_SAVE_DIALOG_FAILED" or value/text()="Couldn&apos;t show file save dialog"'>Não conseguiu abrir o ficheiro guardar diálogo</xsl:if>
<xsl:if test='@name="actionNewActivity.Hint" or value/text()="Create new activity folder"'>Criar nova pasta de actividade</xsl:if>
<xsl:if test='@name="STR_EXCEPTION_EXIT" or value/text()="Do you want to exit the application? If you don&apos;t the application might not behave properly."'>Deseja sair da aplicação? Caso não o pretenda a aplicação poderá não decorrer como desejado.</xsl:if>
<xsl:if test='@name="STR_REMOVE_SUBTITLE_STUDENT_COMMENT" or value/text()="Do you want to remove subtitle&apos;s student comment?"'>Deseja remover o comentário do aluno sobre as legendas?</xsl:if>
<xsl:if test='@name="STR_REMOVE_SUBTITLE_TEACHER_COMMENT" or value/text()="Do you want to remove subtitle&apos;s teacher comment?"'>Deseja remover o comentário do professor sobre as legendas?</xsl:if>
<xsl:if test='@name="dlgImportDocument.Filter" or value/text()="Document files (MHT, HTML, TXT, RTF, DOC, XLS, CSV, PPT, SWF, PDF)|*.mht;*.html;*.htm;*.txt;*.rtf;*.doc;*.xls;*.csv;*.ppt;*.swf;*.pdf|Web archive (MHT)|*.mht|Webpage (HTML)|*.html;*.htm|Text files (TXT, RTF)|*.txt;*.rtf|Word documents (DOC)|*.doc|Excel spreadsheets (XLS, CSV)|*.xls;*.csv|PowerPoint presentations (PPT)|*.ppt|Shockwave files (SWF)|*.swf|PDF documents (PDF)|*.pdf"'>Ficheiros (MHT, HTML, TXT, RTF, DOC, XLS, CSV, PPT, SWF, PDF)|*.mht;*.html;*.htm;*.txt;*.rtf;*.doc;*.xls;*.csv;*.ppt;*.swf;*.pdf|arquivo Web (MHT)|*.mht|Página Web (HTML)|*.html;*.htm|Ficheiros de Texto (TXT, RTF)|*.txt;*.rtf|Documentos Word (DOC)|*.doc|Folhas de Cálculo Excel (XLS, CSV)|*.xls;*.csv|Apresentações PowerPoint (PPT)|*.ppt|Documentos Shockwave (SWF)|*.swf|Documentos PDF|*.pdf</xsl:if>
<xsl:if test='@name="dlgExportDocument.Filter" or value/text()="Document files (MHT, HTML, TXT, RTF, DOC, XLS, CSV, PPT, SWF, PDF)|*.mht;*.html;*.htm;*.txt;*.rtf;*.doc;*.xls;*.csv;*.ppt;*.swf;*.pdf|Web archive (MHT)|*.mht|Webpage (HTML)|*.html;*.htm|Text files (TXT, RTF)|*.txt;*.rtf|Word documents (DOC)|*.doc|Excel spreadsheets (XLS, CSV)|*.xls;*.csv|PowerPoint presentations (PPT)|*.ppt|Shockwave files (SWF)|*.swf|PDF documents (PDF)|*.pdf"'>Ficheiros (MHT, HTML, TXT, RTF, DOC, XLS, CSV, PPT, SWF, PDF)|*.mht;*.html;*.htm;*.txt;*.rtf;*.doc;*.xls;*.csv;*.ppt;*.swf;*.pdf|arquivo Web (MHT)|*.mht|Página Web (HTML)|*.html;*.htm|Ficheiros de Texto (TXT, RTF)|*.txt;*.rtf|Documentos Word (DOC)|*.doc|Folhas de Cálculo Excel (XLS, CSV)|*.xls;*.csv|Apresentações PowerPoint (PPT)|*.ppt|Documentos Shockwave (SWF)|*.swf|Documentos PDF|*.pdf</xsl:if>
<xsl:if test='@name="STR_DURATION" or value/text()="Duration"'>Duração</xsl:if>
<xsl:if test='@name="cbMute.ToolTip" or value/text()="Enable/Disable sound"'>Activar/Desactivar som</xsl:if>
<xsl:if test='@name="STR_END_TIME" or value/text()="End time"'>Tempo Final</xsl:if>
<xsl:if test='@name="STR_ENTER_FOLDER_NAME" or value/text()="Enter folder name"'>Insira o nome da pasta</xsl:if>
<xsl:if test='@name="STR_ENTER_FEEDBACK" or value/text()="Enter your feedback here..."'>Insira as suas sugestões aqui…</xsl:if>
<xsl:if test='@name="STR_ERROR" or value/text()="Error"'>Erro</xsl:if>
<xsl:if test='@name="actionExit.Hint" or value/text()="Exit application"'>Sair da aplicação</xsl:if>
<xsl:if test='@name="actionExportDocument.Hint" or value/text()="Export document"'>Exportar documento</xsl:if>
<xsl:if test='@name="dlgExportDocument.Title" or value/text()="Export document"'>Exportar documento</xsl:if>
<xsl:if test='@name="dlgExportPackedActivity.Title" or value/text()="Export packed activity"'>Exportar actividade compactada</xsl:if>
<xsl:if test='@name="actionExportSubtitles.Hint" or value/text()="Export subtitles"'>Exportar legendas</xsl:if>
<xsl:if test='@name="dlgExportSubtitles.Title" or value/text()="Export subtitles"'>Exportar legendas</xsl:if>
<xsl:if test='@name="actionExportPackedActivity.Hint" or value/text()="Export to packed activity file"'>Exportar para ficheiro de actividades compactado</xsl:if>
<xsl:if test='@name="btnFastBackwards.ToolTip" or value/text()="Fast backwards"'>Recuar</xsl:if>
<xsl:if test='@name="btnFastForward.ToolTip" or value/text()="Fast forward"'>Avançar</xsl:if>
<xsl:if test='@name="btnFaster.ToolTip" or value/text()="Faster (130%)"'>Mais rápido (130%)</xsl:if>
<xsl:if test='@name="STR_FILE_NOT_FOUND" or value/text()="File not found"'>Ficheiro não encontrado</xsl:if>
<xsl:if test='@name="STR_INVALID_FOLDER_NAME_CHARS" or value/text()="Folder name can&apos;t contain the following chars"'>O nome da pasta não pode conter os seguintes caracteres</xsl:if>
<xsl:if test='@name="STR_FOLDER_NOT_FOUND" or value/text()="Folder not found"'>Pasta não encontrada</xsl:if>
<xsl:if test='@name="STR_HELP_NOT_FOUND" or value/text()="Help file not found"'>Ajuda ficheiro não encontrado</xsl:if>
<xsl:if test='@name="dlgImportAudio.Title" or value/text()="Import audio"'>Importar audio</xsl:if>
<xsl:if test='@name="actionImportAudioBrowse.Hint" or value/text()="Import audio file"'>Importar ficheiro audio</xsl:if>
<xsl:if test='@name="dlgImportDocument.Title" or value/text()="Import document"'>Importar documento</xsl:if>
<xsl:if test='@name="actionImportDocumentBrowse.Hint" or value/text()="Import document file"'>Importar ficheiro documento</xsl:if>
<xsl:if test='@name="dlgImportPackedActivity.Title" or value/text()="Import packed activity"'>Importar actividade compactada</xsl:if>
<xsl:if test='@name="actionImportPackedActivity.Hint" or value/text()="Import packed activity file"'>Importar ficheiro pacote de actividades </xsl:if>
<xsl:if test='@name="dlgImportSubtitles.Title" or value/text()="Import subtitles"'>Importar legendas</xsl:if>
<xsl:if test='@name="actionImportSubtitlesBrowse.Hint" or value/text()="Import subtitling file"'>Importar ficheiro de legendas</xsl:if>
<xsl:if test='@name="dlgImportVideo.Title" or value/text()="Import video"'>Importar vídeo</xsl:if>
<xsl:if test='@name="actionImportVideoBrowse.Hint" or value/text()="Import video file"'>Importar ficheiro vídeo</xsl:if>
<xsl:if test='@name="STR_ABOUT" or value/text()="Information"'>Informação</xsl:if>
<xsl:if test='@name="actionShowAbout.Hint" or value/text()="Information about this application"'>Informação sobre esta aplicação</xsl:if>
<xsl:if test='@name="btnAddSubtitle.ToolTipText" or value/text()="Insert new subtitle at current time (F8)"'>Adicionar legenda (F8)</xsl:if>
<xsl:if test='@name="STR_INVALID_SRT" or value/text()="Invalid SRT format"'>Formato SRT Inválido</xsl:if>
<xsl:if test='@name="STR_INVALID_CHANGEFONTSTYLE_PARAM" or value/text()="Invalid style parameter to &apos;ChangeFontStyle&apos; method"'>Parâmetro inválido para o método &apos;MudarTipoDeLetra&apos;</xsl:if>
<xsl:if test='@name="STR_INVALID_TTS" or value/text()="Invalid TTS format"'>Formato TTS Inválido</xsl:if>
<xsl:if test='@name="STR_INVALID_VALUE" or value/text()="Invalid value"'>Valor inválido</xsl:if>
<xsl:if test='@name="actionHelp.Text" or value/text()="LvS &amp;Help"'>LvS &amp;Ajuda</xsl:if>
<xsl:if test='@name="mnuShowHelp.Text" or value/text()="LvS &amp;Help"'>LvS &amp;Ajuda</xsl:if>
<xsl:if test='@name="STR_DURATION_POSITIVE" or value/text()="Must always have &apos;Duration&apos; >= 0"'>Deve ter sempre &apos;duração&apos; >=0</xsl:if>
<xsl:if test='@name="STR_ENDTIME_GREATEREQUAL_STARTTIME" or value/text()="Must always have &apos;End Time&apos; >= &apos;Start Time&apos;"'>Deve ter sempre &apos;Tempo final&apos; >= &apos;Tempo de Início&apos;</xsl:if>
<xsl:if test='@name="STR_NEW_ACTIVITY_FOLDER_NAME" or value/text()="New activity folder name?"'>Nome para nova pasta de actividade</xsl:if>
<xsl:if test='@name="STR_NOT_IMPLEMENTED" or value/text()="Not implemented!"'>Não Implementado!</xsl:if>
<xsl:if test='@name="actionOpenActivityBrowse.Hint" or value/text()="Open activity folder"'>Abrir pasta da actividade</xsl:if>
<xsl:if test='@name="dlgImportPackedActivity.Filter" or value/text()="Packed activity (LVS)|*.lvs"'>Actividade Compactada (LVS)|*.lvs</xsl:if>
<xsl:if test='@name="mnuPageSetup.Text" or value/text()="Page &amp;setup..."'>&amp;Configurar página…</xsl:if>
<xsl:if test='@name="actionPageSetup.Text" or value/text()="Page setup..."'>Configurar página…</xsl:if>
<xsl:if test='@name="btnPause.ToolTip" or value/text()="Pause (F5)"'>Pausa (F5)</xsl:if>
<xsl:if test='@name="btnPlay.ToolTip" or value/text()="Play (F5)"'>Reproduzir (F5)</xsl:if>
<xsl:if test='@name="STR_EXCEPTION_FEEDBACK" or value/text()="Please use Help/Send feedback menu option to report the error details."'>Utilize por favor a opção Ajuda/Enviar (feedback) no menu para nos comunicar possíveis erros.</xsl:if>
<xsl:if test='@name="actionPrintPreview.Hint" or value/text()="Preview printing"'>Pré-visualizar impressão</xsl:if>
<xsl:if test='@name="actionPrint.Hint" or value/text()="Print"'>Imprimir</xsl:if>
<xsl:if test='@name="actionPrintPreview.Text" or value/text()="Print pre&amp;view..."'></xsl:if>
<xsl:if test='@name="mnuPrintPreview.Text" or value/text()="Print pre&amp;view..."'></xsl:if>
<xsl:if test='@name="STR_QUESTION" or value/text()="Question"'>Questão/Pergunta</xsl:if>
<xsl:if test='@name="btnRemoveSubtitle.ToolTipText" or value/text()="Remove subtitle (F9)"'>Eliminar legenda (F9)</xsl:if>
<xsl:if test='@name="btnReplaySelection.ToolTip" or value/text()="Replay selection"'>Repetir selecção</xsl:if>
<xsl:if test='@name="actionSaveActivity.Hint" or value/text()="Save any changes to activity folder"'>Guardar quaisquer alterações na pasta da actividade</xsl:if>
<xsl:if test='@name="STR_SAVEAS" or value/text()="Save file as"'>Guardar ficheiro como</xsl:if>
<xsl:if test='@name="STR_SELECT_ACTIVITY_FOLDER" or value/text()="Select activity folder"'>Seleccione a pasta de actividade</xsl:if>
<xsl:if test='@name="STR_SELECT_PARENT_FOLDER_NEW_ACTIVITY" or value/text()="Select parent folder for new activity subfolder"'>Seleccione a pasta principal para uma nova subpasta da actividade</xsl:if>
<xsl:if test='@name="STR_SELECT_PARENT_FOLDER_UNPACK_ACTIVITY" or value/text()="Select parent folder to unpack activity subfolder"'>Seleccioe a pasta principal para descompactar a subpasta da actividade</xsl:if>
<xsl:if test='@name="actionAuthoringMode.Hint" or value/text()="Select to enable authoring features"'>Seleccionar para activar as propriedades de gravação</xsl:if>
<xsl:if test='@name="actionSendFeedback.Hint" or value/text()="Send feedback"'>Enviar feedback</xsl:if>
<xsl:if test='@name="btnSetSubtitleEnd.Text" or value/text()="Set subtitle &amp;end"'>Definir tempo final</xsl:if>
<xsl:if test='@name="btnSetSubtitleStart.Text" or value/text()="Set subtitle &amp;start"'>Definir tempo &amp;início</xsl:if>
<xsl:if test='@name="btnSetSubtitleEnd.ToolTipText" or value/text()="Set subtitle end (F7)"'>Definir tempo final (F7)</xsl:if>
<xsl:if test='@name="btnSetSubtitleStart.ToolTipText" or value/text()="Set subtitle start (F6)"'>Definir tempo &amp;início (F6)</xsl:if>
<xsl:if test='@name="actionPageSetup.Hint" or value/text()="Set up printer page"'>Configurar página de impressão</xsl:if>
<xsl:if test='@name="actionHelp.Hint" or value/text()="Show documentation"'>Ver documentação</xsl:if>
<xsl:if test='@name="cbSubtitlesOn.ToolTip" or value/text()="Show/Hide subtitles"'>Mostrar/Ocultar legendas</xsl:if>
<xsl:if test='@name="btnSlower.ToolTip" or value/text()="Slower (70%)"'>Mais devagar (70%)</xsl:if>
<xsl:if test='@name="STR_START_TIME" or value/text()="Start time"'>Tempo de Início</xsl:if>
<xsl:if test='@name="STR_STUDENT_COMMENT" or value/text()="Student"'>Aluno</xsl:if>
<xsl:if test='@name="tabNotesStudent.Text" or value/text()="Student notes"'>Notas do aluno</xsl:if>
<xsl:if test='@name="STR_SUBTITLE" or value/text()="Subtitle"'>Legenda</xsl:if>
<xsl:if test='@name="dlgImportSubtitles.Filter" or value/text()="Subtitling files (TTS, SRT)|*.tts;*.srt|TTS files|*.tts|SRT files|*.srt"'>Ficheiros de Legendas (TTS, SRT)|*.tts;*.srt|Ficherios TTS|*.tts|Ficheiros SRT|*.srt</xsl:if>
<xsl:if test='@name="dlgExportSubtitles.Filter" or value/text()="Subtitling files (TTS, SRT, FAB, ENC)|*.tts;*.srt;*.fab;*.enc|TTS files|*.tts|SRT files|*.srt|FAB files|*.fab|Adobe Encore files|*.enc"'>Ficheiros de Legendas (TTS, SRT, FAB, ENC)|*.tts;*.srt;*.fab;*.enc|Ficheiros TTS|*.tts|Ficheiros SRT|*.srt|Ficheiros FAB|*.fab|Ficheiros Adobe Encore|*.enc</xsl:if>
<xsl:if test='@name="STR_TEACHER_COMMENT" or value/text()="Teacher"'>Professor</xsl:if>
<xsl:if test='@name="tabNotesTeacher.Text" or value/text()="Teacher notes"'>Notas do professor</xsl:if>
<xsl:if test='@name="STR_NOT_ACTIVITY_FOLDER" or value/text()="This is not an activity folder"'>Isto não é uma pasta de actividade</xsl:if>
<xsl:if test='@name="STR_VERSION" or value/text()="Version"'>Versão</xsl:if>
<xsl:if test='@name="Version.Text" or value/text()="Version {0}.{1}"'>Versão {0}.{1}</xsl:if>
<xsl:if test='@name="dlgImportVideo.Filter" or value/text()="Video files (MPEG, MPG, MP4, VOB, WMV, AVI, MOV, QT)|*.mpeg;*.mpg;*.mp4;*.vob;*.wmv;*.avi;*.mov;*.qt|MPEG files (MPEG, MPG, MP4, VOB)|*.mpeg;*.mpg;*.mp4;*.vob|Windows Movie files|*.wmv|AVI files|*.avi|QuickTime movies (MOV, QT)|*.mov;*.qt"'>Ficheiros de Vídeo (MPEG, MPG, MP4, VOB, WMV, AVI, MOV, QT)|*.mpeg;*.mpg;*.mp4;*.vob;*.wmv;*.avi;*.mov;*.qt| Ficheiros (MPEG, MPG, MP4, VOB)|*.mpeg;*.mpg;*.mp4;*.vob|Ficheiros Windows Movie (WMV)|*.wmv|Ficheiros AVI|*.avi|Filmes QuickTime (MOV, QT)|*.mov;*.qt</xsl:if>
<xsl:if test='@name="actionPortal.Text" or value/text()="Visit LeViS portal"'>Visitar portal LeVis</xsl:if>
<xsl:if test='@name="mnuPortal.Text" or value/text()="Visit LeViS portal"'>Visitar portal LeVis</xsl:if>
<xsl:if test='@name="actionPortal.Hint" or value/text()="Visit LeViS portal on the web"'>Visitar portal LeVis na Rede</xsl:if>
<xsl:if test='@name="sliderVolume.ToolTip" or value/text()="Volume"'>Volume</xsl:if>
<xsl:if test='@name="STR_VOLUME" or value/text()="Volume"'>Volume</xsl:if>
<xsl:if test='@name="STR_WARNING" or value/text()="Warning"'>Aviso</xsl:if>
<xsl:if test='@name="dlgExportPackedActivity.Filter" or value/text()="Without multimedia  (LVS)|*.lvs|With multimedia (LVS)|*.lvs"'>Sem multimédia (LVS)|*.lvs|Com multimédia (LVS)|*.lvs</xsl:if>
<xsl:if test='@name="STR_PARENT_FOLDER_IS_ACTIVITY" or value/text()="You can&apos;t select an activity folder as parent folder"'>Não pode seleccionar uma pasta de actividade como pasta principal</xsl:if>
  </value>
 </data>
</xsl:template>

<xsl:template match='*'>
 <xsl:copy-of select='.'/>
</xsl:template>

</xsl:stylesheet>
