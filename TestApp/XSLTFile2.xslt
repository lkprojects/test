<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <title>
          מפענח קבצי אחזקות
        </title>
        <style>
          body
          {
          direction:rtl;
          font-family:Arial;
          }

          .TableLevel1 {
          border:solid;
          border-width:thin;
          }
          tr.TableLevel1{
          border: solid;
          border-width: 2px;
          }
          td.TableLevel1{
          border: solid;
          border-width: 1px;
          font-size:11px;
          }

          .Toprow1 {
          background: gray;
          color:white;
          font-size:16px;
          font-weight:bold;
          }

          /*Level 2*/
          .TableLevel2 {
          border:solid;
          border-width:thin;
          }
          tr.TableLevel2{
          border: solid;
          border-width: 2px;
          }
          td.TableLevel2{
          border: solid;
          border-width: 1px;
          font-size:11px;
          }
          .Toprow2 {
          background: red;
          color:white;
          font-size:14px;
          font-weight:bold;

          }

          /*Level 3*/
          .TableLevel3 {
          border:solid;
          border-width:thin;
          }
          tr.TableLevel3{
          border: solid;
          border-width: 2px;
          }
          td.TableLevel3{
          border: solid;
          border-width: 1px;
          font-size:11px;
          }
          .Toprow3 {
          background: orange;
          color:white;
          font-size:12px;
          }
        </style>
      </head>

      <body dir="rtl">
        <h2>מפענח קבצי אחזקות</h2>
        <xsl:apply-templates/>
      </body>
    </html>
  </xsl:template>

  <xsl:template match="/Mimshak">
    <table class="TableLevel1">
      <thead>
        <tr class="TopRow1">
          <td colspan="2">כותרת הקובץ</td>
        </tr>
      </thead>
      <xsl:apply-templates select="KoteretKovetz"/>
      <tr>
        <td colspan="2">
          <table class="TableLevel2">
            <tr class="TopRow2">
              <td colspan="2" class="TopRow2">ישות יצרן</td>
            </tr>
            <xsl:apply-templates select="YeshutYatzran"/>
          </table>
        </td>
      </tr>
      <tr>
        <td colspan="2">
          <table class="TableLevel2">
            <tr class="TopRow2">
              <td colspan="2" class="TopRow2">ישות מתפעל</td>
            </tr>
            <xsl:apply-templates select="YeshutMetafel"/>
          </table>
        </td>
      </tr>
    </table>
  </xsl:template>


  <xsl:template match="KoteretKovetz">
    <xsl:apply-templates select="SUG-MIMSHAK"/>
    <xsl:apply-templates select="MISPAR-GIRSAT-XML"/>
    <xsl:apply-templates select="TAARICH-BITZUA"/>
    <xsl:apply-templates select="KOD-SVIVAT-AVODA"/>
    <xsl:apply-templates select="SHEM-SHOLEACH"/>
    <xsl:apply-templates select="KOD-MEZAHE-METAFEL"/>
    <xsl:apply-templates select="SHEM-METAFEL"/>
    <xsl:apply-templates select="MEZAHE-HAAVARA"/>
    <xsl:apply-templates select="MISPAR-HAKOVETZ"/>
  </xsl:template>

  <xsl:template match="YeshutYatzran">
    <xsl:apply-templates select="KOD-MEZAHE-YATZRAN"/>
    <xsl:apply-templates select="SHEM-YATZRAN"/>
    <tr class="TableLevel3">
      <td colspan="2" class="TableLevel3">
        <table class="TableLevel3">
          <tr class="Toprow3">
            <td colspan="2" class="TableLevel3">אנשי קשר של היצרן</td>
          </tr>
          <xsl:apply-templates select="IshKesherYeshutYatzran"/>
        </table>
      </td>
    </tr>
  </xsl:template>

  <xsl:template match="IshKesherYeshutYatzran">
    <tr class="TableLevel3">
      <td class="TableLevel3">שם</td>
      <td class="TableLevel3">
        <xsl:value-of select="SHEM-PRATI"/>&#160;
        <xsl:value-of select="SHEM-MISHPACHA"/>
      </td>
    </tr>
    <tr class="TableLevel3">
      <td class="TableLevel3">כתובת</td>
      <td class="TableLevel3">
        <xsl:value-of select="SHEM-RECHOV"/>&#160;
        <xsl:value-of select="MISPAR-BAIT"/>&#160;
        <xsl:value-of select="SHEM-YISHUV"/>&#160;
        <xsl:value-of select="MIKUD"/>&#160;
        <xsl:if test="TA-DOAR > 0 ">
          ת.ד. &#160;<xsl:value-of select="TA-DOAR"/>&#160;
        </xsl:if>
        <xsl:value-of select="ERETZ"/>
      </td>
    </tr>
    <tr class="TableLevel3">
      <xsl:if test="MISPAR-TELEPHONE-KAVI != ''">
        <td class="TableLevel3">מס' טלפון קוי</td>
        <td class="TableLevel3">
          <xsl:value-of select="MISPAR-TELEPHONE-KAVI"/>
          <xsl:if test="MISPAR-SHLUCHA != ''">
            שלוחה: &#160; <xsl:value-of select="MISPAR-SHLUCHA"/>
          </xsl:if>
        </td>
      </xsl:if>
    </tr>
    <tr class="TableLevel3">
      <xsl:if test="MISPAR-CELLULARI != ''">
        <td class="TableLevel3">מס' סלולרי</td>
        <td class="TableLevel3">
          <xsl:value-of select="MISPAR-CELLULARI"/>
        </td>
      </xsl:if>
    </tr>
    <tr class="TableLevel3">
      <xsl:if test="MISPAR-FAX != ''">
        <td class="TableLevel3">פקס</td>
        <td class="TableLevel3">
          <xsl:value-of select="MISPAR-FAX"/>
        </td>
      </xsl:if>
    </tr>
    <tr class="TableLevel3">
      <xsl:if test="E-MAIL != ''">
        <td class="TableLevel3">דוא"ל</td>
        <td class="TableLevel3">
          <xsl:value-of select="E-MAIL"/>
        </td>
      </xsl:if>
    </tr>
    <tr class="TableLevel3">
      <xsl:if test="HEAROT != ''">
        <td class="TableLevel3">הערות</td>
        <td class="TableLevel3">
          <xsl:value-of select="HEAROT"/>
        </td>
      </xsl:if>
    </tr>

  </xsl:template>

  <xsl:template match="SUG-MIMSHAK">
    <xsl:if test=". != ''">
      <tr class="TableLevel1">
        <td class="TableLevel1">
          סוג ממשק
        </td>
        <td class="TableLevel1">
          <xsl:choose>
            <xsl:when test=".=1">
              ממשק אחזקות
            </xsl:when>
            <xsl:when test=".=2">
              ממשק טרום יעוץ
            </xsl:when>
            <xsl:when test=".=3">
              ממשק אחזקות + טרום יעוץ
            </xsl:when>
          </xsl:choose>
        </td>
      </tr>
    </xsl:if>
  </xsl:template>

  <xsl:template match="MISPAR-GIRSAT-XML">
    <xsl:if test=". != ''">
      <tr class="TableLevel1">
        <td class="TableLevel1">
          מס' גרסת קובץ
        </td>
        <td class="TableLevel1">
          <xsl:value-of select="."/>
        </td>
      </tr>
    </xsl:if>
  </xsl:template>

  <xsl:template match="TAARICH-BITZUA">
    <xsl:if test=". != ''">
      <tr class="TableLevel1">
        <td class="TableLevel1">
          תאריך ביצוע
        </td>
        <td class="TableLevel1">
          <xsl:value-of select="substring(.,9,2)"/>:<xsl:value-of select="substring(.,11,2)"/>:<xsl:value-of select="substring(.,13,2)"/>&#160;
          <xsl:value-of select="substring(.,7,2)"/>/<xsl:value-of select="substring(.,5,2)"/>/<xsl:value-of select="substring(.,1,4)"/>
        </td>
      </tr>
    </xsl:if>
  </xsl:template>
  <xsl:template match="KOD-SVIVAT-AVODA">
    <xsl:if test=". != ''">
      <tr class="TableLevel1">
        <td class="TableLevel1">
          סביבת עבודה
        </td>
        <td class="TableLevel1">
          <xsl:choose>
            <xsl:when test=".=1">
              בדיקות
            </xsl:when>
            <xsl:when test=".=2">
              ייצור
            </xsl:when>
          </xsl:choose>
        </td>
      </tr>
    </xsl:if>
  </xsl:template>
  <xsl:template match="SHEM-SHOLEACH">
    <xsl:if test=". != ''">
      <tr class="TableLevel1">
        <td class="TableLevel1">
          שם שולח
        </td>
        <td class="TableLevel1">
          <xsl:value-of select="."/>
        </td>
      </tr>
    </xsl:if>
  </xsl:template>
  <xsl:template match="KOD-MEZAHE-METAFEL">
    <xsl:if test=". != ''">
      <tr class="TableLevel1">
        <td class="TableLevel1">
          קוד מזהה מתפעל
        </td>
        <td class="TableLevel1">
          <xsl:value-of select="."/>
        </td>
      </tr>
    </xsl:if>
  </xsl:template>
  <xsl:template match="SHEM-METAFEL">
    <xsl:if test=". != ''">
      <tr class="TableLevel1">
        <td class="TableLevel1">
          שם מתפעל
        </td>
        <td class="TableLevel1">
          <xsl:value-of select="."/>
        </td>
      </tr>
    </xsl:if>
  </xsl:template>

  <xsl:template match="MEZAHE-HAAVARA">
    <xsl:if test=". != ''">
      <tr class="TableLevel1">
        <td class="TableLevel1">
          מזהה קובץ אצל השולח
        </td>
        <td class="TableLevel1">
          <xsl:value-of select="."/>
        </td>
      </tr>
    </xsl:if>
  </xsl:template>

  <xsl:template match="MISPAR-HAKOVETZ">
    <xsl:if test=". != ''">
      <tr class="TableLevel1">
        <td class="TableLevel1">
          מס' הקובץ
        </td>
        <td class="TableLevel1">
          <xsl:value-of select="."/>
        </td>
      </tr>
    </xsl:if>
  </xsl:template>

  <xsl:template match="KOD-MEZAHE-YATZRAN">
    <xsl:if test=". != ''">
      <tr class="TableLevel1">
        <td class="TableLevel1">
          מס' מזהה יצרן(ח.פ.)
        </td>
        <td class="TableLevel1">
          <xsl:value-of select="."/>
        </td>
      </tr>
    </xsl:if>
  </xsl:template>

  <xsl:template match="SHEM-YATZRAN">
    <xsl:if test=". != ''">
      <tr class="TableLevel1">
        <td class="TableLevel1">
          שם יצרן
        </td>
        <td class="TableLevel1">
          <xsl:value-of select="."/>
        </td>
      </tr>
    </xsl:if>
  </xsl:template>

  <xsl:template match="YeshutMetafel">
    <xsl:if test="KOD-MEZAHE-METAFEL != ''">
      <tr class="TableLevel2">
        <td class="TableLevel2">
          קוד מזהה מתפעל (ח.פ.)
        </td>
        <td class="TableLevel2">
          <xsl:value-of select="KOD-MEZAHE-METAFEL"/>
        </td>
      </tr>
    </xsl:if>
    <xsl:if test="SHEM-METAFEL != ''">
      <tr class="TableLevel2">
        <td class="TableLevel2">
          שם מתפעל
        </td>
        <td class="TableLevel2">
          <xsl:value-of select="SHEM-METAFEL"/>
        </td>
      </tr>
      <tr class="TableLevel3">
        <td colspan="2" class="TableLevel3">
          <table class="TableLevel3">
            <tr class="Toprow3">
              <td colspan="2" class="TableLevel3">אנשי קשר של המתפעל</td>
            </tr>
            <xsl:apply-templates select="IshKesherYeshutMetafel"/>
          </table>
        </td>
      </tr>
    </xsl:if>

  </xsl:template>


  <xsl:template match="IshKesherYeshutMetafel">
    <tr class="TableLevel3">
      <td class="TableLevel3">שם</td>
      <td class="TableLevel3">
        <xsl:value-of select="SHEM-PRATI"/>&#160;
        <xsl:value-of select="SHEM-MISHPACHA"/>
      </td>
    </tr>
    <tr class="TableLevel3">
      <td class="TableLevel3">כתובת</td>
      <td class="TableLevel3">
        <xsl:value-of select="SHEM-RECHOV"/>&#160;
        <xsl:value-of select="MISPAR-BAIT"/>&#160;
        <xsl:value-of select="SHEM-YISHUV"/>&#160;
        <xsl:value-of select="MIKUD"/>&#160;
        <xsl:if test="TA-DOAR > 0 ">
          ת.ד. &#160;<xsl:value-of select="TA-DOAR"/>&#160;
        </xsl:if>
        <xsl:value-of select="ERETZ"/>
      </td>
    </tr>
    <tr class="TableLevel3">
      <xsl:if test="MISPAR-TELEPHONE-KAVI != ''">
        <td class="TableLevel3">מס' טלפון קוי</td>
        <td class="TableLevel3">
          <xsl:value-of select="MISPAR-TELEPHONE-KAVI"/>
          <xsl:if test="MISPAR-SHLUCHA != ''">
            שלוחה: &#160; <xsl:value-of select="MISPAR-SHLUCHA"/>
          </xsl:if>
        </td>
      </xsl:if>
    </tr>
    <tr class="TableLevel3">
      <xsl:if test="MISPAR-CELLULARI != ''">
        <td class="TableLevel3">מס' סלולרי</td>
        <td class="TableLevel3">
          <xsl:value-of select="MISPAR-CELLULARI"/>
        </td>
      </xsl:if>
    </tr>
    <tr class="TableLevel3">
      <xsl:if test="MISPAR-FAX != ''">
        <td class="TableLevel3">פקס</td>
        <td class="TableLevel3">
          <xsl:value-of select="MISPAR-FAX"/>
        </td>
      </xsl:if>
    </tr>
    <tr class="TableLevel3">
      <xsl:if test="E-MAIL != ''">
        <td class="TableLevel3">דוא"ל</td>
        <td class="TableLevel3">
          <xsl:value-of select="E-MAIL"/>
        </td>
      </xsl:if>
    </tr>
    <tr class="TableLevel3">
      <xsl:if test="HEAROT != ''">
        <td class="TableLevel3">הערות</td>
        <td class="TableLevel3">
          <xsl:value-of select="HEAROT"/>
        </td>
      </xsl:if>
    </tr>

  </xsl:template>

</xsl:stylesheet>

