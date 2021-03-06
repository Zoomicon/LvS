<?xml version='1.0' encoding='Unicode'?>
<!--
Description: XML stylesheet to keep only "root/data" nodes (with non-empty value) from .RESX file
Author: George Birbilis / Zoomicon (www.zoomicon.com)
Version: 20080210
-->

<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='2.0'>
<xsl:output method='xml' version='1.0' encoding='UTF-8' indent='yes'/>

<xsl:template name='root' match='/root'>
 <root>
  <xsl:apply-templates/>
 </root>
</xsl:template>

<xsl:template match='data'>
 <xsl:if test="./text()">
  <data>
   <name>
    <xsl:copy-of select='@name'/>
   </name>
   <xsl:copy-of select='./*'/>
  </data>
 </xsl:if>
</xsl:template>

<xsl:template match='*'>
 <!-- ignore the rest -->
</xsl:template>

</xsl:stylesheet>
