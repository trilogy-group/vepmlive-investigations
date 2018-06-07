**Jira Ticket:** [EPMLCID-XXXX](https://jira.devfactory.com/browse/EPMLCID-XXXX)
**TeamCity:** [TC Build Link]()

**Changes proposed in the pull request:**


**Test case :**

[Test title](https://testrail.devfactory.com/index.php?/cases/view/)

**Checklist**
- [ ] I checked I'm only including the changes I intend to make and nothing else
- [ ] The PR summary starts with the ticket number, e.g.: 'EPMLCID-?????: ....'
- [ ] The latest changes from the main branch are merged
- [ ] The build/checks have been verified to succeed
- [ ] All the reviewers are assigned (PCA & Peer reviewer at least)
- [ ] The change was tested on local and the demo/evidence attached
- [ ] If this PR is chained to another, have you added a note like: 'IMPORTANT: This PR is chained with #...'

**Checklist for integration tests**
- [ ] IDs, css and then xpaths are preferred
- [ ] All the common code is in appropriate helper 
- [ ] Hard coding is avoided and .constant files are used for keeping constants 
- [ ] `*.constant.ts` has only field/objects/properties but not methods
- [ ] `*.po.ts` has only objects/properties but not methods
- [ ] `*.validation.ts` has only validation related stuff 
- [ ] `*.helper.ts` has only methods and not field/objects/properties
- [ ] Branch name should be automation/EPMLCID-XXXX

To fail the previous checklist will just delay the approval of your PR.

Notes:
- You should not send changes to files because of spacing or formatting if not intended (avoid unnecessary conflicts).
- The chained PR indication allows the reviewer to know if some PR has to be validated/merged before this one.
