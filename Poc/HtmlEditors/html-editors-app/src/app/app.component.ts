import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public header: string;
  public footer: string;

  public ngOnInit(): void{
    this.header = `<p class="MsoNormal">
        <span style="color:#44546A">Hi,<o:p></o:p></span>
        </p>
        <p class="MsoNormal"><span style="color:#1F497D"><o:p>&nbsp;</o:p></span></p>
        <p class="MsoNormal">
        <span style="color:#44546A">
          There has been a change in the seating assignments, please refer to this list below.
        <o:p></o:p>
        </span>
        </p>
        <p class="MsoNormal"><span style="color:#44546A"><o:p>&nbsp;</o:p></span></p>
        <p class="MsoNormal">
        <span style="color:#44546A">
          Also, at the end of the list, there are details and guidelines in place in order to make the move as smooth as possible.
        <b><u>Please read these guidelines.</u></b><o:p></o:p>
        </span>
        </p>`;
    this.footer = `
        <p class="MsoNormal"><b><u><span style="color:#44546A">Move Guidelines:<o:p></o:p></span></u></b></p>
        <p class="MsoNormal"><span style="color:#44546A"><o:p>&nbsp;</o:p></span></p>
        <p class="MsoListParagraph" style="text-indent:-.25in;mso-list:l0 level1 lfo2">
            <><span style="font-family:Symbol;color:#44546A">
                <span style="mso-list:Ignore">
                    &middot;<span style="font:7.0pt &quot;Times New Roman&quot;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </span>
                </span>
            </span><span style="color:#44546A">
                All employees are required to be in their new cubicles by
            </span><span style="color:#1F497D">[MoveDate]</span><span style="color:#44546A">. If you do not know where your new space is, feel free to let me know. &nbsp;If you cannot move by then, please let your Project Manager know.<o:p></o:p></span>
        </p>
        <p class="MsoListParagraph" style="text-indent:-.25in;mso-list:l0 level1 lfo2">
            <><span style="font-family:Symbol;color:#44546A">
                <span style="mso-list:Ignore">
                    &middot;<span style="font:7.0pt &quot;Times New Roman&quot;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </span>
                </span>
            </span><span style="color:#44546A">If you have any questions concerning the location of your new seating assignment, please communicate directly with your Project Manager.<o:p></o:p></span>
        </p>
        <p class="MsoListParagraph" style="text-indent:-.25in;mso-list:l0 level1 lfo2">
            <><span style="font-family:Symbol;color:#44546A">
                <span style="mso-list:Ignore">
                    &middot;<span style="font:7.0pt &quot;Times New Roman&quot;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </span>
                </span>
            </span><span style="color:#44546A">If you require a box to move your belongings, they have at reception. Note that you need to move your phone, docking station, computer lock and screen to your new location.</span><span style="color:#1F497D">
            </span><b><span style="color:#44546A">Please return the box to reception once you no longer need it.</span></b><span style="color:#44546A"><o:p></o:p></span>
        </p>
        <p class="MsoListParagraph" style="text-indent:-.25in;mso-list:l0 level1 lfo2">
            <><span style="font-family:Symbol;color:#44546A">
                <span style="mso-list:Ignore">
                    &middot;<span style="font:7.0pt &quot;Times New Roman&quot;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </span>
                </span>
            </span><span style="color:#44546A">Please ensure your desk is clean and all of your personal belongings are removed so the next person can enjoy their new space.<o:p></o:p></span>
        </p>
        <p class="MsoListParagraph" style="text-indent:-.25in;mso-list:l0 level1 lfo2">
            <><span style="font-family:Symbol;color:#44546A">
                <span style="mso-list:Ignore">
                    &middot;<span style="font:7.0pt &quot;Times New Roman&quot;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </span>
                </span>
            </span><b><span style="color:#44546A">Please do not forget to leave the key to the cubicle drawer on the lock or in the drawer.<o:p></o:p></span></b>
        </p>
        <p class="MsoNormal"><o:p>&nbsp;</o:p></p>
        <p class="MsoNormal">Best,<o:p></o:p></p>
        <p class="MsoNormal"><o:p>&nbsp;</o:p></p>
        <table class="MsoNormalTable" border="1" cellspacing="0" cellpadding="0" width="96%" style="width:96.86%;background:white;border-top:solid #0194D3 1.0pt;border-left:none;border-bottom:solid #0194D3 1.0pt;border-right:none">
            <tbody>
                <tr>
                    <td valign="top" style="border:none;padding:0in 0in 0in 0in">
                        <p class="MsoNormal">
                            <b><span style="font-size:9.0pt;font-family:&quot;Arial&quot;,sans-serif;color:#002D56">Maria Hatajlo</span></b><span style="font-size:9.0pt;font-family:&quot;Arial&quot;,sans-serif;color:#F8971D">
                                |
                            </span><span style="font-size:9.0pt;font-family:&quot;Arial&quot;,sans-serif;color:#ED7D31">Coordinatrice ADM</span><span style="font-size:9.0pt;font-family:&quot;Arial&quot;,sans-serif;color:#F8971D">
                                &nbsp; |&nbsp;
                            </span><span style="font-size:9.0pt;font-family:&quot;Arial&quot;,sans-serif;color:#ED7D31">
                                ADM Practice Coordinator
                            </span><span style="font-size:9.0pt;font-family:&quot;Arial&quot;,sans-serif;color:#F8971D">&nbsp;|</span><span style="font-size:9.0pt;font-family:&quot;Arial&quot;,sans-serif;color:#002D56">
                                <br>
                                T 514.840.6408
                            </span><span style="font-size:9.0pt;font-family:&quot;Arial&quot;,sans-serif;color:#F8971D">
                                |
                            </span><span style="font-size:9.0pt;font-family:&quot;Arial&quot;,sans-serif">do</span><a href="mailto:mhatajlo@TEKsystems.com"><span style="font-size:9.0pt;font-family:&quot;Arial&quot;,sans-serif;color:blue">mhatajlo@TEKsystems.com</span></a><span style="font-size:9.0pt;font-family:&quot;Arial&quot;,sans-serif;color:blue">
                            </span><span style="font-size:9.0pt;font-family:&quot;Arial&quot;,sans-serif;color:#F8971D">|</span><span style="font-size:9.0pt;font-family:&quot;Arial&quot;,sans-serif;color:#002D56">
                                <br>
                                1.866.376.6100 x408 <br>
                                1801 McGill College Av., bureau 1100, Montreal, QC, H3A 3P4
                            </span>
                            <!--<span style="font-size:8.0pt;font-family:&quot;Arial&quot;,sans-serif;color:#002740"><o:p></o:p></span>-->
                        </p>
                    </td>
                </tr>
            </tbody>
        </table>
        <p class="MsoNormal"><o:p>&nbsp;</o:p></p>
        <p class="MsoNormal"><o:p>&nbsp;</o:p></p>`;
  }
  public send(event: any): void{
    alert(this.header + "\r\n" + this.footer);
  }
}
